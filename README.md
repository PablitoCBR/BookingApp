# BookingApp RESTful API
WebAPI  for application providing service for users that can create account for customer or business and as business you can publish your offer and as customer you are able to make a reservation for service. 

##  Task:
- [x] Account creating and authentication system
- [x] User account
- [x] Add roles
- [x] Business account
- [ ] Adding schedule for businesses
- [ ] Adding offers(generalized task)
- [ ] reservations (generalzied task)

#### API:
#
### 1. User Controller
##### **Route**: https://localhost:33224/api/Users/{Method}

##### 1.1. Registering user [guest]
*/register [HttpPost]*
**BODY:**
```
	{
	 "Email" = {email},
	 "Password" = {password},
	 "Name" = {name},
	 "Surname" = {surname}
	}
```

##### 1.2. Verifying registered user [guest]
*/authenticate [HttpPost]*
**BODY:**
```
	{
	 "Email" = {email},
	 "Password" = {password}
	}
```

##### 1.3. Update user data with given id [users access only (account owner)]
*/{id} [HttpPut]*
**BODY:**
```	
	{
	 "Email" = {email},
	 "Username" = {username},
	 "Password" = {password},
	 "Name" = {name},
	 "Surname" = {surname}
	}	
```

##### 1.4. Get user with given id [users acces only (account owner)]
*/{id} [HttpGet]*

##### 1.5. Delete user with given id [users acces only (account owner)]
*/{id} [HttpDelete]*

<hr>

### 2. Business Controller
##### **Route**: https://localhost:33224/api/Business/{Method}

##### 1.1. Registering business [guest]
*/register [HttpPost]*
**BODY:**
```
	{
		"Email": {email},
		"Password": {password},
		"CompanyName": {company name},
		"PhoneNumber": {phone number},
		"Address": {
			"City": {city},
			"PostalCode": {00-000},
			"Street": {street},
			"Number": {number},
			"Flat": {number / null}
		}
	}
```

##### 1.2. Verifying registered business [guest]
*/authenticate [HttpPost]*
**BODY:**
```
	{
	 "Email" = {email},
	 "Password" = {password}
	}
```

##### 1.3. Update business data with given id [users access only (account owner)]
*/{id} [HttpPut]*
**BODY:**
```	
	{
		"Email": {email},
		"Password": {password},
		"CompanyName": {company name},
		"PhoneNumber": {phone number},
		"Address": {
			"City": {city},
			"PostalCode": {00-000},
			"Street": {street},
			"Number": {number},
			"Flat": {number / null}
		}
	}
```

##### 1.4. Get business with given id [users acces only (account owner)]
*/{id} [HttpGet]*

##### 1.5. Delete business with given id [users acces only (account owner)]
*/{id} [HttpDelete]*
