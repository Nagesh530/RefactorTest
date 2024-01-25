
************************************ Nagesh Duggempudi **********************************

Refactored the HarryPotterCalculator class:

		1.Constants and Configuration:

			Introduced constants like Common.BookPrice and Common.MaxBooks for configurability.
			Created a Common class to encapsulate shared constants and methods.

		2.Method Extraction and Encapsulation:

			Extracted logic for calculating minimum cost and writing to a file into separate methods.
			Encapsulated book-related calculations in a dedicated method (CalculateBuyHarryPotter).

		3.Parameterization:

			Updated method signatures to accept arrays and parameters instead of individual variables.
			Passed arrays as parameters for better flexibility and reusability.

		4.Error Handling and Exception Throwing:

			Removed unnecessary goto statements and refactored error-throwing mechanisms for readability.
			Utilized exceptions for cleaner error handling.

		5.Code Organization:

			Grouped related methods and variables together within the class.
			Removed redundant code and improved modularity.

		6.Use of LINQ:

			Employed LINQ expressions for sorting, filtering, and grouping, enhancing readability.
	
		7.Serialization and File Operations:

			Removed redundant file open/close calls and encapsulated file operations in a using block.
	
		8.Comments and Debug Information:

			Added meaningful comments for important sections.
			Utilized Debug.WriteLine for debugging purposes.

		9.Object-Oriented Principles:

			Encapsulated related functionality within the class.
			Applied object-oriented principles for improved maintainability and extensibility.

Refactored the HarryPotterCalculatorUnitTests class:

		1.Consistent Naming:

			Ensure consistent naming of methods and variables. For example, use DeleteInvoiceFile in the Initialize method instead of 
      DeleteInvoice, and use GetInvoiceFileLength instead of GetInvoiceLength.
		
		2.Use TestCleanup:

			Consider using the [TestCleanup] attribute for cleanup tasks to ensure that the invoice file is deleted after each test.

		3.Avoid Hardcoding File Paths:

			Consider making the file path ("Invoice.txt") a constant or a configuration variable to make the code more maintainable.
