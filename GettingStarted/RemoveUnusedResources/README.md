The `RemoveUnusedResources` sample shows how to cleanup a PDF page of unused resources in order to reduce its size after extraction.

Many scanner devices generate PDF files that include all scanned images in a single /Resources dictionary and that dictionary is referenced from all the pages.

When a page is extracted, all the resources in the /Resources dictionary are extracted. For these scanned documents this means that all the scanned images are extracted with each page. When the extracted page is saved as a new document, the size of the new document matches the size of the original file.

A solution to this problem is to scan the page content to detect the resources actually used on the page and remove the unused ones. Since this operation adds an overhead on the page extraction process, it is recomended to used when it is known the source PDF file have this problem.

The sample code implements a custom page transform that scans the page content, keeps track of used resources and removes the unused ones. 

The application code splits a source PDF file into single pages. It shows simple page extraction and saving and in this situation the output files have almost the same size of the source file. It also shows page extraction and saving with removal of unused resources and in this situation the outfiles are much smaller.
