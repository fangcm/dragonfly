using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Dragonfly.Chalk
{
    internal class UpdaterTask
	{
		#region Private fields

		/// <summary>
		/// The task Id.
		/// </summary>
		private Guid id;

		/// <summary>
		/// The base folder where files will be downloaded.
		/// </summary>
		private string donwnloadFilesBase;

		/// <summary>
		/// The task context where all the components can set information for later retrieval.
		/// </summary>
		private readonly StateBag context;

		private readonly string[] files;

		private readonly string[] checksums;

		/// <summary>
		/// The status of the updater task.
		/// </summary>
		private UpdaterTaskState state = UpdaterTaskState.None;

		/// <summary>
		/// An object that can be used to synchronize access to the UpdaterTask.
		/// </summary>
		private readonly object syncRoot = new object();

		#endregion

		#region Constructors

		/// <summary>
		/// Creates an instance of the updater task using the specified manifest.
		/// </summary>
		//FIXME: Add proper parameters
		public UpdaterTask(
			string localBase,
			string remoteBase,
			string[] filesToDownload,
			string productCode,
			string[] checksums)
		{
			id = Guid.NewGuid();
		    this.files = filesToDownload;
            this.donwnloadFilesBase = localBase;
		    this.remoteFilesBase = remoteBase;
			context = new StateBag();
		    Description = "NA";
		    this.ProductCode = productCode;
		    this.checksums = checksums;
			//Init( manifest );
		}

		#endregion

		#region UpdaterTask Members

		/// <summary>
		/// A property bag where components can set key-value pairs of information for later retrieval.
		/// </summary>
		/// <param name="key">The index key of the item to locate.</param>
		public object this[ string key ]
		{
			get
			{
				return context[ key ];
			}
			set
			{
				context[ key ] = value;
			}
		}

		/// <summary>
		/// Gets an object that can be used to synchronize access to the UpdaterTask.
		/// </summary>
		public object SyncRoot
		{
			get { return syncRoot; }
		}

		/// <summary>
		/// The base folder where files will be downloaded.
		/// </summary>
		public string DownloadFilesBase
		{
			get
			{
				return donwnloadFilesBase;
			}
		}

	    private string remoteFilesBase;

        public string RemoteFilesBase
        {
            get
            {
                return remoteFilesBase;
            }
        }

	    /// <summary>
		/// Initializes an existing UpdaterTask with the specified manifest.
		/// </summary>
		public void Init()
		{
			//this.manifest = manifest;
			// CHANGED
            donwnloadFilesBase = Path.Combine( Utility.TempBasePath, "downloader" );
		    donwnloadFilesBase = Path.Combine( donwnloadFilesBase, ProductCode );
			donwnloadFilesBase = Path.Combine( donwnloadFilesBase, id.ToString() );
		}

		/// <summary>
		/// An unique identifier for the UpdaterTask.
		/// </summary>
		public Guid TaskId
		{
			get
			{
				return id;
			}
		}

		/// <summary>
		/// The current state of the UpdaterTask.
		/// <see cref="UpdaterTaskState"/>
		/// </summary>
		public UpdaterTaskState State
		{
			get
			{
				return state;
			}
			set
			{
				state = value;
			}
		}

	    public string[] Files { get { return files; } }

        public string[] Checksums { get { return checksums; } }

        public bool Downloaded { get; set; }
        
        public string Description { get; set; }

        public string ProductCode { get; set; }
	    public string Version { get; set; } 

//		/// <summary>
//		/// The manifest corresponding to the current UpdaterTask.
//		/// </summary>
//		public Manifest Manifest
//		{
//			get
//			{
//				return manifest;
//			}
//		}
		
		#endregion

		#region ISerializable Members

//		/// <summary>
//		/// Constructor to support serialization required for storing the task.
//		/// </summary>
//		/// <param name="info">The serialization information.</param>
//		/// <param name="context">The serialization context.</param>
//		[SecurityPermission(SecurityAction.LinkDemand)]
//		protected UpdaterTask(SerializationInfo info, StreamingContext context)
//		{
//			manifest = (Manifest)info.GetValue( "_manifest", typeof( Manifest) );
//			state = (UpdaterTaskState)info.GetValue( "_state",typeof( UpdaterTaskState) );
//			id = (Guid)info.GetValue( "_id", typeof( Guid ) );
//			this.context = (StateBag)info.GetValue( "_context", typeof( StateBag ) );
//			donwnloadFilesBase = (string)info.GetValue( "_donwnloadFilesBase", typeof( string ) );
//		}

		/// <summary>
		/// Method used by the seralization mechanism to retrieve the serialized information.
		/// </summary>
		/// <param name="info">The serialization information.</param>
		/// <param name="context">The serialization context.</param>
		[SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			//info.AddValue( "_manifest", manifest );
			info.AddValue( "_state", state );
			info.AddValue( "_id", id );
			//info.AddValue( "_context", this.context );
			info.AddValue( "_donwnloadFilesBase", donwnloadFilesBase );
		}

		#endregion

    }
}
