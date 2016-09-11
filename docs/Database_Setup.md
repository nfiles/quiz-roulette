# Database Setup

Directory: `src/QuizRoulette.Database`

```text
# Install postgres
$ sudo apt-get install postgres

# Connect to postgres instance
$ sudo -u postgres psql

# Create database for existing user
postgres=# CREATE DATABASE $dbname WITH OWNER $USER;

# Exit postgresql-client
postgres=# \q

# Set the connection string in configuration
$ dotnet user-secrets set ConnectionStrings:DefaultConnection "$CONNECTION_STRING"

# Update database from EF Entities
$ dotnet ef database update
```
