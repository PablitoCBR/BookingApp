BookingApp RESTful API

Project goals:
	1) user (some kind of bussiness) can create an accout
	2) verified user can create their own working hours
	3) users cab manage their schedules
	4) guest can book service from user for particular date
	5) users have to confirm reservation
	6) guest can cancel reservation

Working functionality:
	1) user (some kind of bussiness) can create an accout
	

API Working modules:
	1)UsersController
	Route: https://localhost:44337/api/Users/{Method}

	Methods:

	1.1) Registering user [guest]
	/register [HttpPost]
	BODY:
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

	1.2) Verifying registered user [guest]
	/authenticate [HttpPost]
	BODY:
	{
	 "Username" = {username},
	 "Password" = {password
	}

	1.3) Update user data [users acces only]
	/{id} [HttpPut]
	BODY:
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

	1.4) Get all users [users acces only]
	/ [HttpGet]

	1.5) Get user by id [users acces only]
	/{id} [HttpGet]

	1.6) Delete user with id=? [users acces only]
	/{id} [HttpDelete]

	
	