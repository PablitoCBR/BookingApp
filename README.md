# BookingApp CRUD API
WebAPI  for application providing service for users that can create account for customer or business and as business you can publish your offer and as customer you are able to make a reservation for service. 

##  Task:
- [x] Account creating and authentication system
- [x] User account
- [x] Add roles
- [x] Business account
- [x] Adding schedule for businesses
- [x] Reservations 
- [x] Business search

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
##### If closed on given day set opening and closing to null
*/{id} [HttpPost]*
**BODY:**
```
{
	"Monday":{
		"Opening": {00:00/null},
		"Closing": {00:00/null}
	},
	"Tuesday":{
		"Opening": {00:00/null},
		"Closing": {00:00/null}
	},
	"Wednesday":{
		"Opening": {00:00/null},
		"Closing": {00:00/null}
	},
	"Thursday":{
		"Opening": {00:00/null},
		"Closing": {00:00/null}
	},
	"Friday":{
		"Opening": {00:00/null},
		"Closing": {00:00/null}
	},
	"Saturday":{
		"Opening": {00:00/null},
		"Closing": {00:00/null}
	},
	"Sunday":{
		"Opening": {00:00/null},
		"Closing": {00:00/null}
	}	
}
```

#### 3.2. Get schedule of business with given id [guest]
*/{id} [HttpGet]*

#### 3.3 Remove schedule of business with given id [Bussiness access only (account owner)]
*/{id} [HttpDelete]*

#### 3.4 Update schedule of business with given id [Bussiness access only (account owner)]
##### If closed on given day set opening and closing to null
*/{id} [HttpPut]*

**BODY:**
```
{
	"Monday":{
		"Opening": {00:00/null},
		"Closing": {00:00/null}
	},
	"Tuesday":{
		"Opening": {00:00/null},
		"Closing": {00:00/null}
	},
	"Wednesday":{
		"Opening": {00:00/null},
		"Closing": {00:00/null}
	},
	"Thursday":{
		"Opening": {00:00/null},
		"Closing": {00:00/null}
	},
	"Friday":{
		"Opening": {00:00/null},
		"Closing": {00:00/null}
	},
	"Saturday":{
		"Opening": {00:00/null},
		"Closing": {00:00/null}
	},
	"Sunday":{
		"Opening": {00:00/null},
		"Closing": {00:00/null}
	}	
}
```

<hr>

### 4. Reservation Controller
##### **Route**: https://localhost:33224/api/Reservation/{Method}

#### 4.1 Make reservation (reservation assigned to user by JWT) [Users access only]
*/make [HttpPost]*
**BODY:**
```
{
	"BusinessID": {id of business},
	"Date": {mm/dd/yyyy hh:mm:ss AM/PM},
	"Duration": {duration of reservation in minutes}
}
```

#### 4.2 Cancel reservation [Users and Businesses access only]
*/cancel/{reservation_id} [HttpDelete]*

#### 4.3 Confirm reservation [Business asigned to reservation access only]
*/confirm/{reservation_id} [HtppPut]*

#### 4.4 Get reservation [User or Business asigned to reservation access only]
*/{reservation_id} [HttpGet]*

#### 4.5 Get cureent reservations [Users and Businesses access only]
*/ [HttpGet]*

#### 4.6 Get previous reservations [Users and Businesses access only]
*/history [HttpGet]*

<hr>

### 5. Searcg Controller
##### **Route**: https://localhost:33224/api/Search/{Method}

#### 5.1 Search by company name [guest]
*/{company_name_patter} [HttpGet]*
