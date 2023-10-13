## Steps taken to build traditional CRUD functionality

	1. Scaffold CRUD with Entity Framework tools (dotnet-aspnet-codegenerator)
	2. Fix errors: e.g. don't bind a PK on a Create			
	3. Modify to use our Repository pattern		
	4. Remove async/await because our Repository methods are synchronous
	5. Put SQL scripts into a Data folder since we forgot to do so earlier
	6. Add links in navbar for convenience
	7. Add phone number and email validation in the Seller model class		
	8. Don't allow a new Seller to be created if it has the same Tax ID as an existing Seller

### Scaffold REST API with an ApiController to provide "CRUD" for AJAX

	1. Scaffold a new API controller for Sellers with dotnet-aspnet-codegenerator
	2. Customize, fix things and use our Repository
	3. Fix problem with cycles in JSON serialization
	4. And finish writing the PUT method, which is surprisingly complex for only keeping the TaxID unique and not allowing it to be changed