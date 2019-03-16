# BookingApp RESTful API
WebAPI  for application providing service for users that can create account for customer or business and as business you can publish your offer and as customer you are able to make a reservation for service. 

##  Task:
- [x] Account creating and authentication system
- [x] User account
- [x] Add roles
- [x] Business account
- [x] Adding schedule for businesses
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

##### 2.1. Registering business [guest]
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

##### 2.2. Verifying registered business [guest]
*/authenticate [HttpPost]*
**BODY:**
```
	{
	 "Email" = {email},
	 "Password" = {password}
	}
```

##### 2.3. Update business data with given id [users access only (account owner)]
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

##### 2.4. Get business with given id [users acces only (account owner)]
*/{id} [HttpGet]*

##### 2.5. Delete business with given id [users acces only (account owner)]
*/{id} [HttpDelete]*

<hr>

### 3. Schedule Controller
##### **Route**: https://localhost:33224/api/Schedule/{Method}

#### 3.1. Add new schedule for business [Bussiness access only (account owner)]
##### If closed on given day set Hours and Minutes of opening and closeing to null
*/{id} [HttpPost]*
**BODY:**
```
	{
		"Monday":{
			"Opening":{
				"Hours": {(0-23)} / null,
				"Minutes": {(0-59)} / null
			},
			"Closeing":{
				"Hours": {(0-23)} / null,
				"Minutes": {(0-59)} / null
			}
		},
		"Tuesday":{
			"Opening":{
				"Hours": {(0-23)} / null,
				"Minutes": {(0-59)} / null
			},
			"Closeing":{
				"Hours": {(0-23)} / null,
				"Minutes": {(0-59)} / null
			}
		},
		"Wednesday":{
			"Opening":{
				"Hours": {(0-23)} / null,
				"Minutes": {(0-59)} / null
			},
			"Closeing":{
				"Hours": {(0-23)} / null,
				"Minutes": {(0-59)} / null
			}
		},
		"Thursday":{
			"Opening":{
				"Hours": {(0-23)} / null,
				"Minutes": {(0-59)} / null
			},
			"Closeing":{
				"Hours": {(0-23)} / null,
				"Minutes": {(0-59)} / null
			}
		},
		"Friday":{
			"Opening":{
				"Hours": {(0-23)} / null,
				"Minutes": {(0-59)} / null
			},
			"Closeing":{
				"Hours": {(0-23)} / null,
				"Minutes": {(0-59)} / null
			}
		},
		"Saturday":{
			"Opening":{
				"Hours": {(0-23)} / null,
				"Minutes": {(0-59)} / null
			},
			"Closeing":{
				"Hours": {(0-23)} / null,
				"Minutes": {(0-59)} / null
			}
		},
		"Sunday":{
			"Opening":{
				"Hours": {(0-23)} / null,
				"Minutes": {(0-59)} / null
			},
			"Closeing":{
				"Hours": {(0-23)} / null,
				"Minutes": {(0-59)} / null
			}
		}
		
	}
```

#### 3.2. Get schedule of business with given id [guest]
*/{id} [HttpGet]*

#### 3.3 Remove schedule of business with given id [Bussiness access only (account owner)]
*/{id} [HttpDelete]*

#### 3.4 Update schedule of business with given id [Bussiness access only (account owner)]
##### If closed on given day set Hours and Minutes of opening and closeing to null
*/{id} [HttpPut]*

**BODY:**
```
	{
		"Monday":{
			"Opening":{
				"Hours": {(0-23)} / null,
				"Minutes": {(0-59)} / null
			},
			"Closeing":{
				"Hours": {(0-23)} / null,
				"Minutes": {(0-59)} / null
			}
		},
		"Tuesday":{
			"Opening":{
				"Hours": {(0-23)} / null,
				"Minutes": {(0-59)} / null
			},
			"Closeing":{
				"Hours": {(0-23)} / null,
				"Minutes": {(0-59)} / null
			}
		},
		"Wednesday":{
			"Opening":{
				"Hours": {(0-23)} / null,
				"Minutes": {(0-59)} / null
			},
			"Closeing":{
				"Hours": {(0-23)} / null,
				"Minutes": {(0-59)} / null
			}
		},
		"Thursday":{
			"Opening":{
				"Hours": {(0-23)} / null,
				"Minutes": {(0-59)} / null
			},
			"Closeing":{
				"Hours": {(0-23)} / null,
				"Minutes": {(0-59)} / null
			}
		},
		"Friday":{
			"Opening":{
				"Hours": {(0-23)} / null,
				"Minutes": {(0-59)} / null
			},
			"Closeing":{
				"Hours": {(0-23)} / null,
				"Minutes": {(0-59)} / null
			}
		},
		"Saturday":{
			"Opening":{
				"Hours": {(0-23)} / null,
				"Minutes": {(0-59)} / null
			},
			"Closeing":{
				"Hours": {(0-23)} / null,
				"Minutes": {(0-59)} / null
			}
		},
		"Sunday":{
			"Opening":{
				"Hours": {(0-23)} / null,
				"Minutes": {(0-59)} / null
			},
			"Closeing":{
				"Hours": {(0-23)} / null,
				"Minutes": {(0-59)} / null
			}
		}
		
	}
```