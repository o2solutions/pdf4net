using System;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Core.Security;

namespace O2S.Components.PDF4NET.Samples
{
    /// <summary>
    /// Represents the output of a sample.
    /// </summary>
    public class SampleOutputInfo
    {
        /// <summary>
        /// Initializes a new <see cref="SampleOutputInfo"/> object.
        /// </summary>
        /// <param name="document">The document that represents the sample output</param>
        /// <param name="fileName">The file name of the sample output</param>
        public SampleOutputInfo(PDFDocument document, string fileName) : this(document, fileName, null)
        {
        }

        /// <summary>
        /// Initializes a new <see cref="SampleOutputInfo"/> object.
        /// </summary>
        /// <param name="document">The document that represents the sample output</param>
        /// <param name="fileName">The file name of the sample output</param>
        /// <param name="securityHandler">Security handler for encrypting the output document</param>
        public SampleOutputInfo(PDFDocument document, string fileName, PDFSecurityHandler securityHandler)
        {
            this.document = document;
            this.fileName = fileName;
            this.securityHandler = securityHandler;
        }

        private PDFDocument document;
        /// <summary>
        /// Gets or sets the document that represents the sample output.
        /// </summary>
        public PDFDocument Document
        {
            get { return document; }
            set { document = value; }
        }

        private string fileName;
        /// <summary>
        /// Gets or sets the file name the sample is saved to disk.
        /// </summary>
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        private PDFSecurityHandler securityHandler;
        /// <summary>
        /// Gets or sets the security handler used to encrypt the output file.
        /// </summary>
        public PDFSecurityHandler SecurityHandler
        {
            get { return securityHandler; }
            set { securityHandler = value; }
        }
    }
}