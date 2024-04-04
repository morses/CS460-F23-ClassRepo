# Setup

1. Set two application secrets, one for the password of each seeded user, and one for the seeded Admin user: "SeedUserPW" and "SeedAdminPW" respectively.		
2. Create DB's as usual: application and authentication.
3. To run the BDD tests you'll need to set up SpecFlow and have the appropriate browser driver installed.

The application creates 5 plain old users upon startup, and one Admin user.  For some of the features to be available, the Admin
must add questions to the database for students to answer.  This can be done by logging in as the Admin user and navigating to the
Admin page and the Questions CRUD landing page, which is just a simple CRUD scaffolding for that model.  
