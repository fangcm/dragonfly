﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.IO;

namespace Dragonfly.Netdisk
{
    public static class Operation
    {
        public static QuotaResult GetQuota(Credential credential)
        {
            try
            {
                using (var wc = new WebClient())
                {
                    wc.Headers.Add(HttpRequestHeader.Cookie, credential);
                    var res = wc.DownloadString("http://pan.baidu.com/api/quota?checkexpire=1&checkfree=1");
                    var obj = JsonConvert.DeserializeObject<QuotaResult>(res);
                    obj.success = true;
                    return obj;
                }
            }
            catch (Exception ex)
            {
                return new QuotaResult() { exception = ex };
            }
        }
        public static UserInfoResult GetUserInfo(Credential credential)
        {
            try
            {
                if (credential.uid <= 0) throw new Exception("Invalid uid.");
                using (var wc = new WebClient())
                {
                    wc.Headers.Add(HttpRequestHeader.Cookie, credential);
                    var res = wc.DownloadString("http://pan.baidu.com/api/user/getinfo?user_list=[" + credential.uid + "]");
                    var obj = JsonConvert.DeserializeObject<UserInfoResult>(res);
                    obj.success = true;
                    return obj;
                }
            }
            catch (Exception ex)
            {
                return new UserInfoResult() { exception = ex };
            }
        }
        public static FileListResult GetFileList(string path, Credential credential)
        {
            try
            {
                using (var wc = new WebClient())
                {
                    wc.Headers.Add(HttpRequestHeader.Cookie, credential);
                    var res = wc.DownloadString("http://pan.baidu.com/api/list?page=1&num=10000000&dir=" + Uri.EscapeDataString(path));
                    var obj = JsonConvert.DeserializeObject<FileListResult>(res);
                    obj.success = true;
                    return obj;
                }
            }
            catch (Exception ex)
            {
                return new FileListResult() { exception = ex };
            }
        }
        public static ThumbnailResult GetThumbnail(string path, Credential credential, int width = 125, int height = 90, int quality = 100)
        {
            try
            {
                using (var wc = new WebClient())
                {
                    wc.Headers.Add(HttpRequestHeader.Cookie, credential);
                    var res = wc.DownloadData("http://pcsdata.baidu.com/rest/2.0/pcs/thumbnail?app_id=250528&method=generate&path=" + Uri.EscapeDataString(path) + "&quality=" + quality + "&height=" + height + "&width=" + width);
                    return new ThumbnailResult() { success = true, image = res };
                }
            }
            catch (Exception ex)
            {
                return new ThumbnailResult() { exception = ex };
            }
        }
        public static GetDownloadResult GetDownload(string path, Credential credential)
        {
            try
            {
                using (var wc = new WebClient())
                {
                    wc.Headers.Add(HttpRequestHeader.Cookie, credential);
                    wc.Headers.Add(HttpRequestHeader.UserAgent, "netdisk;5.4.5.4;PC;PC-Windows;10.0.14393;WindowsBaiduYunGuanJia");
                    var res = wc.DownloadString("http://d.pcs.baidu.com/rest/2.0/pcs/file?app_id=250528&method=locatedownload&ver=4.0&path=" + Uri.EscapeDataString(path));
                    var obj = JsonConvert.DeserializeObject<GetDownloadResult>(res);
                    obj.success = true;
                    return obj;
                }
            }
            catch (Exception ex)
            {
                return new GetDownloadResult() { exception = ex };
            }
        }
        public static FileOperationResult CreateFolder(string path, Credential credential)
        {
            try
            {
                using (var wc = new WebClient())
                {
                    wc.Headers.Add(HttpRequestHeader.Cookie, credential);
                    wc.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
                    var str = "isdir=1&path=" + Uri.EscapeDataString(path);
                    var res = wc.UploadData("http://pan.baidu.com/api/create?a=commit", Encoding.UTF8.GetBytes(str));
                    var obj = JsonConvert.DeserializeObject<FileOperationResult>(Encoding.UTF8.GetString(res));
                    obj.success = true;
                    return obj;
                }
            }
            catch (Exception ex)
            {
                return new FileOperationResult() { exception = ex };
            }
        }
        public static FileOperationResult Copy(string path, string dest, string newname, Credential credential)
        {
            var str = "filelist=[{\"path\":\"" + Uri.EscapeDataString(path) + "\",\"dest\":\"" + Uri.EscapeDataString(dest) + "\",\"newname\":\"" + Uri.EscapeDataString(newname) + "\"}]";
            return FileOp("http://pan.baidu.com/api/filemanager?opera=copy&clienttype=8", str, credential);
        }
        public static FileOperationResult Delete(string path, Credential credential)
        {
            var str = "filelist=[\"" + Uri.EscapeDataString(path) + "\"]";
            return FileOp("http://pan.baidu.com/api/filemanager?opera=delete&clienttype=8", str, credential);
        }
        public static FileOperationResult Move(string path, string dest, string newname, Credential credential)
        {
            var str = "filelist=[{\"path\":\"" + Uri.EscapeDataString(path) + "\",\"dest\":\"" + Uri.EscapeDataString(dest) + "\",\"newname\":\"" + Uri.EscapeDataString(newname) + "\"}]";
            return FileOp("http://pan.baidu.com/api/filemanager?opera=move&clienttype=8", str, credential);
        }
        public static FileOperationResult Rename(string path, string newname, Credential credential)
        {
            var str = "filelist=[{\"path\":\"" + Uri.EscapeDataString(path) + "\",\"newname\":\"" + Uri.EscapeDataString(newname) + "\"}]";
            return FileOp("http://pan.baidu.com/api/filemanager?opera=rename&clienttype=8", str, credential);
        }
        private static FileOperationResult FileOp(string url, string str, Credential credential)
        {
            try
            {
                using (var wc = new WebClient())
                {
                    wc.Headers.Add(HttpRequestHeader.Cookie, credential);
                    wc.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
                    var res = wc.UploadData(url, Encoding.UTF8.GetBytes(str));
                    var obj = JsonConvert.DeserializeObject<FileOpResult>(Encoding.UTF8.GetString(res));
                    if (obj.info.Length == 0 && obj.errno != 0)
                        return new FileOperationResult() { success = true, errno = obj.errno };
                    else if (obj.info.Length == 0 || obj.errno != 0 && obj.info[0].errno == 0)
                        throw new Exception("Response data malformat.");
                    else
                        return new FileOperationResult() { success = true, errno = obj.info[0].errno, path = obj.info[0].path };
                }
            }
            catch (Exception ex)
            {
                return new FileOperationResult() { exception = ex };
            }
        }
        public static OfflineListResult GetOfflineList(Credential credential)
        {
            try
            {
                using (var wc = new WebClient())
                {
                    wc.Headers.Add(HttpRequestHeader.Cookie, credential);
                    var res1 = wc.DownloadString("http://pan.baidu.com/rest/2.0/services/cloud_dl?app_id=250528&method=list_task&need_task_info=1&status=255");
                    var ltr = JsonConvert.DeserializeObject<ListTaskResult>(res1);
                    if (ltr.task_info.Length == 0) return new OfflineListResult() { success = true, tasks = new OfflineListResult.Entry[0] };
                    var str = "method=query_task&op_type=1&task_ids=" + Uri.EscapeDataString(string.Join(",", ltr.task_info.Select(e => e.task_id.ToString())));
                    wc.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
                    var res2 = wc.UploadData("http://pan.baidu.com/rest/2.0/services/cloud_dl?app_id=250528", Encoding.UTF8.GetBytes(str));
                    var qtr = JsonConvert.DeserializeObject<QueryTaskResult>(Encoding.UTF8.GetString(res2));
                    return new OfflineListResult()
                    {
                        tasks = ltr.task_info.Select(e =>
                        {
                            var ai = qtr.task_info[e.task_id.ToString()];
                            return new OfflineListResult.Entry()
                            {
                                create_time = e.create_time,
                                od_type = e.od_type,
                                save_path = e.save_path,
                                source_url = e.source_url,
                                task_id = e.task_id,
                                task_name = e.task_name,
                                file_size = ai.file_size,
                                finished_size = ai.finished_size,
                                status = ai.status
                            };
                        }).ToArray(),
                        success = true
                    };
                }
            }
            catch (Exception ex)
            {
                return new OfflineListResult() { exception = ex };
            }
        }
        public static Result CancelOfflineTask(long taskid, Credential credential)
        {
            return OfflineTaskOp(taskid, "cancel_task", credential);
        }
        public static Result DeleteOfflineTask(long taskid, Credential credential)
        {
            return OfflineTaskOp(taskid, "delete_task", credential);
        }
        public static Result ClearOfflineTask(Credential credential)
        {
            return OfflineTaskOp(0, "clear_task", credential);
        }
        private static Result OfflineTaskOp(long taskid, string oper, Credential credential)
        {
            try
            {
                using (var wc = new WebClient())
                {
                    wc.Headers.Add(HttpRequestHeader.Cookie, credential);
                    wc.DownloadData("http://pan.baidu.com/rest/2.0/services/cloud_dl?app_id=250528&method=" + oper + "&task_id=" + taskid);
                    return new Result() { success = true };
                }
            }
            catch (Exception ex)
            {
                return new Result() { exception = ex };
            }
        }
        public static QueryLinkResult QueryLinkFiles(string link, Credential credential)
        {
            try
            {
                using (var wc = new WebClient())
                {
                    wc.Headers.Add(HttpRequestHeader.Cookie, credential);
                    wc.Headers.Add(HttpRequestHeader.UserAgent, "netdisk;5.4.5.4;PC;PC-Windows;10.0.14393;WindowsBaiduYunGuanJia");
                    if (link.StartsWith("magnet:", StringComparison.OrdinalIgnoreCase))
                    {
                        var res = wc.DownloadString("http://pan.baidu.com/rest/2.0/services/cloud_dl?app_id=250528&clienttype=8&method=query_magnetinfo&source_url=" + Uri.EscapeDataString(link));
                        var obj = JsonConvert.DeserializeObject<QueryMagnetResult>(res);
                        return new QueryLinkResult() { success = true, files = obj.magnet_info };
                    }
                    else if (link.EndsWith(".torrent", StringComparison.OrdinalIgnoreCase))
                    {
                        var res = wc.DownloadString("http://pan.baidu.com/rest/2.0/services/cloud_dl?app_id=250528&clienttype=8&method=query_sinfo&type=2&source_path=" + Uri.EscapeDataString(link));
                        var obj = JsonConvert.DeserializeObject<QueryTorrentResult>(res);
                        return new QueryLinkResult() { success = true, files = obj.torrent_info.file_info };
                    }
                    else throw new Exception("Not a magnet link or a torrent file.");
                }
            }
            catch (Exception ex)
            {
                return new QueryLinkResult() { exception = ex };
            }
        }
        public static AddOfflineTaskResult AddOfflineTask(string link, string savepath, Credential credential, int[] selected = null, string sha1 = "")
        {
            try
            {
                var str = "method=add_task&save_path=" + Uri.EscapeDataString(savepath) + "&";
                if (link.StartsWith("http://", StringComparison.OrdinalIgnoreCase) || link.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                    str += "type=0&source_url=" + Uri.EscapeDataString(link);
                else if (link.StartsWith("ed2k://", StringComparison.OrdinalIgnoreCase))
                    str += "type=3&source_url=" + Uri.EscapeDataString(link);
                else if (link.StartsWith("magnet:", StringComparison.OrdinalIgnoreCase))
                    str += "type=4&task_from=5&source_url=" + Uri.EscapeDataString(link) + "&selected_idx=" + string.Join(",", selected.Select(i => i.ToString()));
                else if (link.EndsWith(".torrent", StringComparison.OrdinalIgnoreCase))
                    str += "type=2&task_from=5&file_sha1=" + sha1 + "&source_path=" + Uri.EscapeDataString(link) + "&selected_idx=" + string.Join(",", selected.Select(i => i.ToString()));
                else throw new Exception("Link invalid.");
                using (var wc = new WebClient())
                {
                    wc.Headers.Add(HttpRequestHeader.Cookie, credential);
                    wc.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
                    wc.Headers.Add(HttpRequestHeader.UserAgent, "netdisk;5.4.5.4;PC;PC-Windows;10.0.14393;WindowsBaiduYunGuanJia");
                    var res = wc.UploadData("http://pan.baidu.com/rest/2.0/services/cloud_dl?app_id=250528&clienttype=8", Encoding.UTF8.GetBytes(str));
                    var obj = JsonConvert.DeserializeObject<AddOfflineTaskResult>(Encoding.UTF8.GetString(res));
                    obj.success = true;
                    return obj;
                }
            }
            catch (Exception ex)
            {
                return new AddOfflineTaskResult() { exception = ex };
            }
        }
        public static ShareResult Share(string[] pathlist, Credential credential, string pwd = null)
        {
            try
            {
                if (pwd != null && pwd.Length != 4) throw new Exception("Length of pwd must be 4.");
                var str = "path_list=[" + string.Join(",", pathlist.Select(p => '"' + Uri.EscapeDataString(p) + '"')) + "]&channel_list=[]&shorturl=1&";
                if (pwd == null) str += "public=1&schannel=0";
                else str += "public=0&schannel=4&pwd=" + pwd;
                var rand = new Random();
                var logid = new string(Enumerable.Range(0, 100).Select(i => (char)('a' + rand.Next(26))).ToArray());
                using (var wc = new WebClient())
                {
                    wc.Headers.Add(HttpRequestHeader.Cookie, credential);
                    wc.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
                    var res = wc.UploadData("http://pan.baidu.com/share/pset?clienttype=8&channel=00000000000000000000000000000000&version=5.4.5.4&devuid=123456&logid=" + logid, Encoding.UTF8.GetBytes(str));
                    var obj = JsonConvert.DeserializeObject<ShareResult>(Encoding.UTF8.GetString(res));
                    obj.success = true;
                    return obj;
                }
            }
            catch (Exception ex)
            {
                return new ShareResult() { exception = ex };
            }
        }
        public static TransferResult Transfer(string url, string path, Credential credential, string pwd = null)
        {
            try
            {
                using (var wc = new CookieAwareWebClient())
                {
                    wc.Cookies.Add(credential);
                    var str = wc.DownloadString(url);
                    var rurl = wc.ResponseUri.ToString();
                    string shareid = null, uk = null;
                    if (rurl.Contains("/share/init"))
                    {
                        if (pwd == null) throw new Exception("Need password.");
                        shareid = Regex.Match(rurl, "shareid=(\\d+)").Groups[1].Value;
                        uk = Regex.Match(rurl, "uk=(\\d+)").Groups[1].Value;
                        wc.Headers.Add(HttpRequestHeader.Referer, rurl);
                        wc.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
                        var res = wc.UploadData("http://pan.baidu.com/share/verify?shareid=" + shareid + "&uk=" + uk, Encoding.UTF8.GetBytes("vcode=&vcode_str=&pwd=" + pwd));
                        var obj = JsonConvert.DeserializeObject<VerifyPwdResult>(Encoding.UTF8.GetString(res));
                        if (obj.errno != 0) throw new Exception("Password verification returned errno = " + obj.errno);
                        str = wc.DownloadString(url);
                    }
                    str = Regex.Match(str, "yunData.setData(.*)").Groups[1].Value.Trim();
                    str = str.Substring(1, str.Length - 3);
                    var obj2 = JsonConvert.DeserializeObject<SharePageData>(str);
                    str = "path=" + Uri.EscapeDataString(path) + "&filelist=[" + string.Join(",", obj2.file_list.list.Select(e => "\"" + Uri.EscapeDataString(e.path) + "\"")) + "]";
                    wc.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
                    wc.Headers.Add(HttpRequestHeader.Referer, url);
                    var rand = new Random();
                    var logid = new string(Enumerable.Range(0, 100).Select(i => (char)('a' + rand.Next(26))).ToArray());
                    var res2 = wc.UploadData("http://pan.baidu.com/share/transfer?channel=chunlei&clienttype=0&web=1&app_id=250528&ondup=newcopy&async=1&shareid=" + shareid + "&from=" + uk + "&logid=" + logid + "&bdstoken=" + obj2.bdstoken, Encoding.UTF8.GetBytes(str));
                    var obj3 = JsonConvert.DeserializeObject<TransferResult>(Encoding.UTF8.GetString(res2));
                    obj3.success = true;
                    return obj3;
                }
            }
            catch (Exception ex)
            {
                return new TransferResult() { exception = ex };
            }
        }
        public static CommitUploadResult SimpleUpload(string localpath, string remotepath, Credential credential, string host = "c.pcs.baidu.com")
        {
            try
            {
                var size = new FileInfo(localpath).Length;
                var mtime = (long)(new FileInfo(localpath).LastAccessTime.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                var md5 = UploadHelper.GetMD5HashFromFile(localpath);
                var str = "path=" + remotepath + "&size=" + size + "&isdir=0&block_list=[\"" + md5 + "\"]&autoinit=1&local_mtime=" + mtime + "&method=post";
                using (var wc = new PatientWebClient())
                {
                    wc.Headers.Add(HttpRequestHeader.Cookie, credential);
                    wc.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
                    var res = wc.UploadData("http://pan.baidu.com/api/precreate?clienttype=8", Encoding.UTF8.GetBytes(str));
                    var obj = JsonConvert.DeserializeObject<InitUploadResult>(Encoding.UTF8.GetString(res));
                    if (obj.errno != 0) throw new Exception("precreate had errno = " + obj.errno);
                    var boundary = GetBoundary();
                    wc.Headers.Add(HttpRequestHeader.ContentType, "multipart/form-data; boundary=" + boundary);
                    str = "--" + boundary + "\r\nContent-Disposition: form-data; name=\"filename\"; filename=\"name\"\r\nContent-Type: application/octet-stream\r\n\r\n";
                    var str2 = "\r\n--" + boundary + "--\r\n";
                    var data = Encoding.UTF8.GetBytes(str).Concat(File.ReadAllBytes(localpath)).Concat(Encoding.UTF8.GetBytes(str2)).ToArray();
                    res = wc.UploadData("http://" + host + "/rest/2.0/pcs/superfile2?app_id=250528&method=upload&path=" + Uri.EscapeDataString(remotepath) + "&uploadid=" + Uri.EscapeDataString(obj.uploadid) + "&partseq=0&partoffset=0", data);
                    str = "path=" + remotepath + "&size=" + size + "&isdir=0&uploadid=" + Uri.EscapeDataString(obj.uploadid) + "&block_list=[\"" + md5 + "\"]&method=post&rtype=2&sequence=1&mode=1&local_mtime=" + mtime;
                    res = wc.UploadData("http://pan.baidu.com/api/create?a=commit&clienttype=8", Encoding.UTF8.GetBytes(str));
                    var obj2 = JsonConvert.DeserializeObject<CommitUploadResult>(Encoding.UTF8.GetString(res));
                    obj2.success = true;
                    return obj2;
                }
            }
            catch (Exception ex)
            {
                return new CommitUploadResult() { exception = ex };
            }
        }
        public static RapidUploadResult RapidUpload(FileProperty prop, string path, Credential credential)
        {
            try
            {
                using (var wc = new WebClient())
                {
                    wc.Headers.Add(HttpRequestHeader.Cookie, credential);
                    wc.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
                    var str = "path=" + Uri.EscapeDataString(path) + "&content-length=" + prop.size + "&content-md5=" + prop.md5 + "&slice-md5=" + prop.slice_md5 + "&content-crc32=" + prop.crc32 + "&local_mtime=" + prop.mtime + "&block_list=[" + string.Join(",", prop.blocks.Select(h => '"' + h + '"')) + "]&rtype=2";
                    var res = wc.UploadData("http://pan.baidu.com/api/rapidupload?clienttype=8", Encoding.UTF8.GetBytes(str));
                    var obj = JsonConvert.DeserializeObject<RapidUploadResult>(Encoding.UTF8.GetString(res));
                    obj.success = true;
                    return obj;
                }
            }
            catch (Exception ex)
            {
                return new RapidUploadResult() { exception = ex };
            }
        }
        public static InitUploadResult InitUpload(FileProperty prop, string path, Credential credential)
        {
            try
            {
                using (var wc = new WebClient())
                {
                    wc.Headers.Add(HttpRequestHeader.Cookie, credential);
                    wc.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
                    var str = "path=" + Uri.EscapeDataString(path) + "&size=" + prop.size + "&isdir=0&local_mtime=" + prop.mtime + "&block_list=[" + string.Join(",", prop.blocks.Select(h => '"' + h + '"')) + "]&autoinit=1&method=post";
                    var res = wc.UploadData("http://pan.baidu.com/api/precreate?clienttype=8", Encoding.UTF8.GetBytes(str));
                    var obj = JsonConvert.DeserializeObject<InitUploadResult>(Encoding.UTF8.GetString(res));
                    obj.success = true;
                    return obj;
                }
            }
            catch (Exception ex)
            {
                return new InitUploadResult() { exception = ex };
            }
        }
        public static Result UploadBlock(FileProperty prop, string path, InitUploadResult session, FileStream stream, int blockid, string host, Credential credential)
        {
            try
            {
                using (var wc = new PatientWebClient())
                {
                    var boundary = GetBoundary();
                    wc.Headers.Add(HttpRequestHeader.Cookie, credential);
                    wc.Headers.Add(HttpRequestHeader.ContentType, "multipart/form-data; boundary=" + boundary);
                    var str = "--" + boundary + "\r\nContent-Disposition: form-data; name=\"filename\"; filename=\"name\"\r\nContent-Type: application/octet-stream\r\n\r\n";
                    var str2 = "\r\n--" + boundary + "--\r\n";
                    stream.Seek((long)blockid * 4 * 1024 * 1024, SeekOrigin.Begin);
                    var fdata = new byte[4 * 1024 * 1024];
                    var len = stream.Read(fdata, 0, fdata.Length);
                    if (len < fdata.Length)
                    {
                        var arr = new byte[len];
                        Array.Copy(fdata, arr, len);
                        fdata = arr;
                    }
                    var data = Encoding.UTF8.GetBytes(str).Concat(fdata).Concat(Encoding.UTF8.GetBytes(str2)).ToArray();
                    var res = wc.UploadData("http://" + host + "/rest/2.0/pcs/superfile2?app_id=250528&method=upload&path=" + Uri.EscapeDataString(path) + "&uploadid=" + Uri.EscapeDataString(session.uploadid) + "&partseq=" + blockid + "&partoffset=" + (long)blockid * 4 * 1024 * 1024, data);
                    var obj = JsonConvert.DeserializeObject<SuperFileResponse>(Encoding.UTF8.GetString(res));
                    if (obj.md5 != prop.blocks[blockid]) throw new Exception("MD5 mismatch.");
                    return new Result() { success = true };
                }
            }
            catch (Exception ex)
            {
                return new Result() { exception = ex };
            }
        }
        public static CommitUploadResult CommitUpload(FileProperty prop, string path, InitUploadResult session, Credential credential)
        {
            try
            {
                using (var wc = new WebClient())
                {
                    wc.Headers.Add(HttpRequestHeader.Cookie, credential);
                    wc.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
                    var str = "path=" + path + "&size=" + prop.size + "&isdir=0&uploadid=" + Uri.EscapeDataString(session.uploadid) + "&block_list=[" + string.Join(",", prop.blocks.Select(h => '"' + h + '"')) + "]&method=post&rtype=2&sequence=1&mode=1&local_mtime=" + prop.mtime;
                    var res = wc.UploadData("http://pan.baidu.com/api/create?a=commit&clienttype=8", Encoding.UTF8.GetBytes(str));
                    var obj = JsonConvert.DeserializeObject<CommitUploadResult>(Encoding.UTF8.GetString(res));
                    obj.success = true;
                    return obj;
                }
            }
            catch (Exception ex)
            {
                return new CommitUploadResult() { exception = ex };
            }
        }
        public static CommitUploadResult ChunkedUpload(string localpath, string remotepath, Credential credential)
        {
            try
            {
                var servers = GetUploadServers(credential);
                if (!servers.success) throw servers.exception;
                var prop = UploadHelper.GetFileProperty(localpath);
                var session = InitUpload(prop, remotepath, credential);
                if (!session.success) throw session.exception;
                if (session.errno != 0) throw new Exception("Init upload returned errno = " + session.errno);
                using (var fs = new FileStream(localpath, FileMode.Open))
                {
                    for (int i = 0; i < prop.blocks.Length; i++)
                    {
                        var res = UploadBlock(prop, remotepath, session, fs, i, servers.servers[0], credential);
                        if (!res.success) throw res.exception;
                    }
                }
                var comres = CommitUpload(prop, remotepath, session, credential);
                if (!comres.success) throw comres.exception;
                if (comres.errno != 0) throw new Exception("Commit upload returned errno = " + comres.errno);
                return comres;
            }
            catch (Exception ex)
            {
                return new CommitUploadResult() { exception = ex };
            }
        }
        public static GetUploadServersResult GetUploadServers(Credential credential)
        {
            try
            {
                using (var wc = new WebClient())
                {
                    wc.Headers.Add(HttpRequestHeader.Cookie, credential);
                    wc.Headers.Add(HttpRequestHeader.UserAgent, "netdisk;5.4.5.4;PC;PC-Windows;10.0.14393;WindowsBaiduYunGuanJia");
                    var res = wc.DownloadString("http://d.pcs.baidu.com/rest/2.0/pcs/file?app_id=250528&method=locateupload&esl=1&ehps=0&upload_version=2.0");
                    var obj = JsonConvert.DeserializeObject<LocateUploadResponse>(res);
                    return new GetUploadServersResult() { success = true, servers = obj.servers.Select(s => Regex.Match(s.server, ":\\/\\/(.+)$").Groups[1].Value).ToArray() };
                }
            }
            catch (Exception ex)
            {
                return new GetUploadServersResult() { exception = ex };
            }
        }
        private static string GetBoundary()
        {
            var rand = new Random();
            var sb = new StringBuilder();
            for (int i = 0; i < 28; i++) sb.Append('-');
            for (int i = 0; i < 15; i++) sb.Append((char)(rand.Next(0, 26) + 'a'));
            var boundary = sb.ToString();
            return boundary;
        }
        private class FileOpResult
        {
            public int errno;
            public Entry[] info;
            public class Entry
            {
                public int errno;
                public string path;
            }
        }
        private class ListTaskResult
        {
            public Entry[] task_info;
            public class Entry
            {
                public long create_time;
                public int od_type;
                public string save_path;
                public string source_url;
                public long task_id;
                public string task_name;
            }
        }
        private class QueryTaskResult
        {
            public Dictionary<string, Entry> task_info;
            public class Entry
            {
                public long file_size;
                public long finished_size;
                public int status;
            }
        }
        private class QueryTorrentResult
        {
            public TorrentInfo torrent_info;
            public class TorrentInfo
            {
                public QueryLinkResult.Entry[] file_info;
                public string sha1;
            }
        }
        private class QueryMagnetResult
        {
            public QueryLinkResult.Entry[] magnet_info;
        }
        private class VerifyPwdResult
        {
            public int errno;
        }
        private class SharePageData
        {
            public string bdstoken;
            public FileList file_list;
            public class FileList
            {
                public Entry[] list;
                public class Entry
                {
                    public string path;
                }
            }
        }
        private class SuperFileResponse
        {
            public string md5;
        }
        private class LocateUploadResponse
        {
            public Entry[] servers;
            public class Entry
            {
                public string server;
            }
        }
    }
}
