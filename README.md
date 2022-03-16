# [PDF4NET](https://o2sol.com/pdf4net/overview.htm)

This repository contains all the samples for [**PDF4NET**](https://o2sol.com/pdf4net/overview.htm) .NET library.

[**PDF4NET**](https://o2sol.com/pdf4net/overview.htm) is a .NET library for generating and importing PDF documents on the fly from any .NET application. The library does not rely on any Adobe products for creating and importing PDF files. It hides the complex structure of PDF files behind a simple object model that allows creation of complex PDF files or import of existing PDF files with a few lines of code. It supports a wide set of features, ranging from simple PDF creation to form filling, content redaction, complex color conversions or digital signatures.

The [**PDF4NET**](https://o2sol.com/pdf4net/overview.htm) library can use either a grid based layout approach allowing precise positioning of content on document's pages or a flow based layout making the generation of complex documents a breeze. The final PDF file is compressed, making the library appropriate for web applications. The library can be used from WinForms, ASP.NET, WPF, UWP, .NET Core, Mac, iOS and Android applications without any restrictions, the source code being fully portable between platforms. The library is written entirely in C#, being 100% managed.

The [**PDF4NET**](https://o2sol.com/pdf4net/overview.htm) library is licensed per developer and can be distributed ROYALTY FREE, reducing your project costs.

The main features of [**PDF4NET**](https://o2sol.com/pdf4net/overview.htm) library are outlined below:

##### SUPPORTED PLATFORMS	 
  - .NET Framework 4.x	
  - .NET 5
  - Windows Forms	
  - Xamarin.Mac	
  - ASP.NET Webforms and MVC	
  - Console applications	
  - Windows services	
  - Mono	
  - WPF 4.x	
  - Xamarin.iOS	
  - Xamarin.Android	
  - Xamarin.Forms	
  - Portable Class Library	
  - Universal Windows Platform	
  - .NET Core	
  - .NET Standard	

##### DOCUMENT FEATURES	 
 
  - Create and load PDF documents from files and streams	
  - Grid layout and/or flow layout modes	
  - Save PDF files in PDF/A-1B, PDF/A-2 B/U, PDF/A-3 B/U format	
  - Save PDF files in PDF/UA-1 format	
  - Save PDF files to disk and streams	
  - PDF structure compression	
  - Document information and custom properties	
  - Document viewer preferences and display modes	
  - XMP metadata	
  - Document file attachments	
  - Document level Javascripts and actions	
  - Document outline (bookmarks)	
  - Create CAD and geospatial enabled PDF files	
  - Add, remove and read Bates numbers	
  - Add and remove PDF pages	
  - Page boxes - media box, crop box, art box, trim box and bleed box	
  - Page labeling ranges (page numbering)	
  - Extract pages from external PDF files	
  - Append PDF pages	
  - Split PDF files into pages	
  - Document incremental updates	
  - Partial document loading and saving	
 
##### LOGICAL STRUCTURE & TAGGED PDF & ACCESSIBILITY	 
 
  - Logical document structure	
  - Tagged PDF	
  - Structure tree and structure elements	
  - ID map	
  - Role map	
  - Structure element attributes	
  - Attribute classes	
  - PDF/UA-1	
  - Automatic tagging of flow documents	
  - Extraction of page content with associated logical structure information
 
##### FLOW DOCUMENT FEATURES	 
 
  - Mixed formatted text	
  - Superscript/subscript text	
  - Images	
  - Form XObjects	
  - Annotations	
  - Tables	
  - Headers and footers	
  - Table of contents	
  - Automatic tagging for accessibility	
  - Before/After draw events for flow content	
 
##### SECURITY	 
 
  - User and owner passwords	
  - Document access rights	
  - 40 bit and 128 bit RC4 encryption	
  - 128 bit and 256 bit AES encryption	
  - Content redaction	
  - Disable text copy/paste	
 
##### DIGITAL SIGNATURES	 
 
  - Approval and certifying digital signatures with X509 certificates	
  - Basic CMS and PAdES digital signatures with SHA256 / SHA384 / SHA512	
  - Signature timestamps	
  - OCSP and CRL information included in digital signatures	
  - Document security store	
  - Document timestamps	
  - LTV (Long Term Validation) enabled digital signatures	
  - Support for hardware signature tokens/smartcards (Windows, WPF, Mac)	
  - Externally computed signatures	
  - Load digital signatures from signed PDF files	Yes
  - Decode existing signatures into basic ASN.1 blocks	Yes
  - Extract the certificate from digital signatures	Yes
  - Save the signed copy of a PDF document 

##### GRAPHICS FEATURES	 
 
  - Grid layout for fixed content positioning	
  - Flow layout for relative content positioning	
  - All PDF color spaces: DeviceRGB, DeviceCMYK, DeviceGray, Indexed, CalGray, CalRGB, Lab, ICC, Separation, DeviceN and PANTONE colors	
  - Pen and brush objects for stroking and filling operations	
  - Hatch style brushes	
  - Graphics primitives: lines, ellipses, rectangles, rounded rectangles, arcs, pies, chords, Bezier curves, paths	
  - Clipping paths	
  - Images (see Images section) and form XObjects	
  - Transparency groups	
  - Single line and multi line text with vertical and horizontal aligment, including justified text	
  - Extended graphics states with support for fill and stroke alpha, blend modes and overprinting	
  - Affine transformations: multiply, translate, rotate and scale	
  - Shadings - function, axial and radial	
  - Patterns - colored, uncolored and shading	
  - Optional content (layers) with support for custom display trees, multipage and mixed layers	
  - Barcodes (see Barcodes section)	
  - Drawing of external page content (page imposition)	
  - Low level PDF graphics for full control over the page content stream	
  - Formatted content (paragraphs, text blocks, styled text, links inside text, bullet lists)	
  - Tables (simple and composite cells, column spans, row spans, borders)	
 
##### FONTS	 
 
  - Standard PDF fonts, Western and CJK	
  - Type1 fonts	
  - Type3 fonts	
  - Ansi and Unicode TrueType fonts with support for font subsetting	
  - Disable text copy/paste for Unicode TrueType fonts	
 
##### IMAGES	 
 
  - Load images from files and streams	
  - Png, Gif, Jpeg, Jpeg2000, Tiff and Raw images	
  - Extra large JPEG images	
  - Extra large TIFF images (24bpp and 32bpp, uncompressed, zip, lzw)	
  - Create images from System.Drawing.Bitmap (WinForms) (BMP, GIF, PNG, TIFF, JPG)	
  - Native support for TIFF (grayscale, RGB and CMYK), JPEG, PNG and RAW images	
  - TIFF to PDF conversion with CCITT G4 compression for B/W images	
  - Image masks: color masks, stencil mask and soft masks	
  - Alternate images for printing	
  - SVG to PDF conversion	
 
##### BARCODES	 
 
  - Built in vector barcode engine, no barcode images or barcode fonts	
  - Unidimensional barcodes:	
    - Generic barcodes: Codabar, Code 11, Code 25, Code 25 Interleaved, Code 39, Code 39 Extended, Code 93, Code 93 Extended, Code 128 A, Code 128 B, Code 128 C, COOP 25, Matrix 25, MSI/Plessey	
    - Pharmaceutical barcodes: Code 32, Pharmacode, PZN (Pharma-Zentral-Nummer)	
    - EAN/UPC barcodes: EAN 128, EAN-13, EAN-8, ISBN, ISMN, ISSN, JAN-13, UPC-A, UPC-E	
    - Postal and transportation barcodes: FedEx Ground 96, IATA 25, Identcode, Leitcode, KIX, Planet, PostNet, RM4SCC, SCC-14,  SingaporePost, SSCC-18, USPS FIM, USPS Horizontal, USPS PIC	
  - Bidimensional barcodes:	
    - DataMatrix, QR, PDF417, Micro PDF417, Codablock F, Code 16K	
 
##### PDF ANNOTATIONS	 
 
  - Add, edit and remove PDF annotations	
  - Standard and custom appearance for annotations	
  - Flatten annotations	
  - Supported annotations:	
    - Text (sticky notes) annotations	
    - Rubber stamp annotations	
    - Square and circle annotations	
    - File attachment annotations	
    - Link annotations (hyperlinks)	
    - Line annotations	
    - Ink annotations	
    - Polygon and polyline annotations	
    - Text markup annotations: highlight, underline, strikeout, squiggly	
    - Free text (typewritter) annotations	
    - Sound annotations	
    - Movie annotations	
    - Rich media (Flash) annotations	
    - Redaction annotations	
    - 3D annotations with support for: views, projections, lighting schemes,
      cross sections, backgrounds and animations	
 
##### PDF FORMS (Acrobat forms)	 
 
  - Create, load and save PDF forms	
  - Add, edit, remove and rename form fields	
  - Support for text box fields, combo box fields, list box fields,   push button fields, check box fields, radio button fields, signature fields	
  - Read/Write (fill) form fields	
  - Create custom appearances for field widgets	
  - Flatten form fields	
  - Form actions (see PDF actions)	
 
##### PDF ACTIONS	 
 
  - Add, edit and remove PDF actions	
  - Set actions at document level, page level, annotation level and form field level	
  - Supported actions:	
    - GoTo actions - go to destinations in current PDF file	
    - Remote GoTo actions - go to destinations in external PDF files	
    - GoTo 3D view actions - activate a specific view in a 3D annotation	
    - Lauch actions - launch executables and files	
    - URI actions - go to a web based destination	
    - Named actions - predefined PDF actions	
    - Javascript actions - execute Javascript code	
    - Submit form actions - submit form data to a server	
    - Reset form actions - reset form fields to default values	
    - Hide actions - show or hide form fields	
 
##### PDF FUNCTIONS	 
 
  - Sample based functions (Type 0)	
  - Exponential functions (Type 2)	
  - Stitching functions (Type 3)	
  - Postscript calculator functions (Type 4)	
 
##### TEXT SEARCH	 
 
  - Search text in PDF pages with support for regular search, case sensitive search, whole word search and regular expression search	
 
##### CONTENT EXTRACTION	 
 
  - Extract text with position information at fragment level and glyph level	
  - Extract text as words with position information at word level and glyph level	
  - Extract text and words from user defined regions	
  - Extract images including image information such as: image size in pixels,  bits per pixel, colorspace, image position on the PDF page, image size on the PDF page, image horizontal and vertical resolution	
  - Extract page content as a sequence of path, text, image and shading objects	
  - Extract optional content groups as vector drawings	
  - Extract page content as vector drawings	
 
##### CONTENT TRANSFORMATION	 
 
  - Convert page content to RGB	
  - Convert page content to CMYK	
  - Convert page content to Grayscale	
  - Convert images to Grayscale	
  - Replace page images	
  - Remove page images	
 
##### CONTENT REDACTION	 
 
  - Text redaction	
  - Image redaction	
  - Redaction annotations	
 
##### PDF PORTFOLIOS	 
 
  - Create and load PDF portfolios	
  - Define portfolio attributes and define sort order for portfolio items	
  - Add and remove portfolio items	
  - Organize portfolio items into folders	
 
##### LOW LEVEL COS API	 
 
  - Add, edit and remove COS objects	
  - Supported COS objects: strings, numbers, names, booleans, nulls,
  arrays, dictionaries and streams	

##### PDF RENDERING (included in PDF4NET+Render package)	 
 
  - Convert PDF pages to color, grayscale and black & white images
  - Convert PDF pages to RAW, PNG and TIFF (single and multi-page)
  - Native RGBA, BGRA, ARGB, RGB, BGR and Grayscale rendering
  - Built-in graphic engine that produces pixel matched results across all supported platforms
  - Selective content rendering: text and/or vector graphics and/or images and/or form fields and/or annotations
  - Supported PDF features:
      - Stroked and filled vector graphics
      - Clipping paths including text based clipping paths
      - Text (all text rendering modes)
      - Fonts (standard PDF fonts, embedded fonts, TrueType, Type1, Type3)
      - Images (RAW, DCT/JPEG, CCITT, JPEG2000, JBIG2, inline) with associated masks if present
      - Colorspaces (RGB, CMYK, Gray, CalRGB, CalGray, Lab, ICC, Separation, DeviceN, Indexed)
      - Graphics state soft masks
      - Transparency groups
      - Blend modes
      - PDF patterns
      - PDF shadings (gradients)
 
##### LICENSING	 
 
  - Per developer licensing with royalty free distribution	

##### CLASS REFERENCE

[**PDF4NET**](https://o2sol.com/pdf4net/overview.htm) class reference is available here: [PDF4NET Class Reference](https://o2sol.com/pdf4net/help/pdf4net/webframe.html)

The classic Hello PDF sample looks like this with [**PDF4NET**](https://o2sol.com/pdf4net/overview.htm):
```
PDFFixedDocument document = new PDFFixedDocument();
PDFPage page = document.Pages.Add();
page.Canvas.DrawString("Hello PDF", new PDFStandardFont(), new PDFBrush(), 50, 50);
document.Save("HelloPDF.pdf");
```

