# BookingApp RESTful API

## Project goals:
 [x] user (some kind of bussiness) can create an accout
 [x] verified user can create their own working hours
 [x] users can manage their schedules
 [ ] guest can book service from user for particular date
 [ ] users have to confirm reservation
 [ ] guest can cancel reservation

#### API:

### 1. User Controller
##### **Route**: https://localhost:44337/api/Users/{Method}
#
##### 1.1. Registering user [guest]
*/register [HttpPost]*
**BODY:**
```
	{
	 "Username" = {username},
	 "Password" = {password},
	 "BusinessName" = {businessName},
	 "Address" = 
		{
		 "City" = {city},
		 "PostalCode = {postalCode},   <-- only like "00-000"
		 "Street" = {street},
		 "Number" = {number},
		 "Flat" = {flat/null},
		}
	}
```

##### 1.2. Verifying registered user [guest]
*/authenticate [HttpPost]*
**BODY:**
```
	{
	 "Username" = {username},
	 "Password" = {password
	}
```

##### 1.3. Update user data [users acces only]
*/{id} [HttpPut]*
**BODY:**
```	{
	 "Username" = {username},
	 "Password" = {password},
	 "BusinessName" = {businessName},
	 "Address" = 
		{
		 "City" = {city},
		 "PostalCode = {postalCode},   <-- only like "00-000"
		 "Street" = {street},
		 "Number" = {number},
		 "Flat" = {flat/null},
		}
	}	
```

##### 1.4. Get all users [users acces only]
*/ [HttpGet]*

##### 1.5. Get user by id [users acces only]
*/{id} [HttpGet]*

##### 1.6. Delete user with id=? [users acces only]
*/{id} [HttpDelete]*

	
### 2. ScheduleController
##### **Route**: https://localhost:44337/api/Schedule/{Method}
#
#### 2.1. Create new schedule [users acces only]
*/Create [HttpPost]*
**HEADERS:**
```
Key: id Vaule: {id of user}
```
**BODY:** *(if closed on a given day set opening and closeing to **null**)*
```
		[
			{
				"Day": "0",
				"Opening": {hh:mm:ss},
				"Closeing": {hh:mm:ss}
			},
				{
				"Day": "1",
				"Opening": {hh:mm:ss},
				"Closeing": {hh:mm:ss}
			},
				{
				"Day": "2",
				"Opening": {hh:mm:ss},
				"Closeing": {hh:mm:ss}
			},
				{
				"Day": "3",
				"Opening": {hh:mm:ss},
				"Closeing": {hh:mm:ss}
			},
				{
				"Day": "4",
				"Opening": {hh:mm:ss},
				"Closeing": {hh:mm:ss}
			},
				{
				"Day": "5",
				"Opening": {hh:mm:ss},
				"Closeing": {hh:mm:ss}
			},
				{
				"Day": "6",
				"Opening": null,
				"Closeing": null
			}
		]
```
#### 2.2 Get schedule of given user [guest]
*/{id} [HttpGet]* 

#### 2.3) Remove schedule of given user [users acces only]
*/{id} [HttpDelete]*

#### 2.4) Update schedule of given user
*/{id} [HttpPut]*

**BODY:**
```
	[
		{
			"Day": "4",
			"Opening": {hh:mm:ss},
			"Closeing": {hh:mm:ss}
		},
		{
			"Day": "5",
			"Opening": {hh:mm:ss},
			"Closeing": {hh:mm:ss}
		}
	]
```
