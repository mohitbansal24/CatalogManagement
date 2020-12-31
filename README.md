# **Catalog Management System** 
This solution will consolidate the product catalog from different companies into one superset. On intial load, it will merge the catalog into a super and will work for BAU mode on adding and removing the Products.

**Getting Started** : 
These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

**Prerequisites** :
Visual Studio, .Net Framework 4.6.1 

**Installing**
- Clone the repo to your local system.
- Open in Visual  Studio
- Restore the nuget packages, no other configuration is required to run solution locally.
- Build and run
- Input  and Output files are located at root under respective folders.  
- Logging is done using NLog which will push the logs to Nlog.log

**Running the tests** : 
Solution has 4 automated test cases to cater Merge of catalog and consolidation. 

Scenarios 1 and 2  : Validating the total count of records in Master list
Scenarios 3 and 4  : Consolidating the catalog and comapring it with standard output for given set of input 

- Run the test using Visual Studio test, on average it takes 40 ms to complete all 4 test cases but depends on machine configuration
