The `ContentSeparator` sample shows how to separate the content of a PDF page based on the color used to paint the page content.

The `PDFSeparateContentTransform` class is used to implement a page transform that analyzes the page content and keeps or discards the content based on specific conditions. The class uses a separation color space as filter for page content. 

The `PDFSeparateContentTransform` class is initialized with the separation name and a flag that indicates whether to keep the content painted with the separation color or discard it. When the flag is true, the transform keeps only the content painted with the separation colorspace and the other content is discarded. When the flag is false, the transform discards the content painted with the separation colorspace and keeps the remaining content. 

The transform caches the current path building operators and when a path painting operator is encountered, the path is either painted or discarded based on current condition.