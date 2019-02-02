<h1>BookingApp RESTful API</h1>
<hr>
<h3>Project goals:</h3>
	<h5>1) user (some kind of bussiness) can create an accout</h5>
	<h5>2) verified user can create their own working hours</h5>
	<h5>3) users can manage their schedules</h5>
	<h5>4) guest can book service from user for particular date</h5>
	<h5>5) users have to confirm reservation</h5>
	<h5>6) guest can cancel reservation</h5>
<br>
<h3>Working functionality:</h3>
	<h5>1) user (some kind of bussiness) can create an accout</h5>
	<h5>2) verified user can create their own working hours</h5>
<br>
<hr>

<h3>API Working modules: </h3>

<h4>1)UsersController</h4>
<h4>Route: https://localhost:44337/api/Users/{Method}</h4>

	Methods:

	1.1) Registering user [guest]
	*/register [HttpPost]*
	**BODY:**
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
	*/authenticate [HttpPost]*
	**BODY:**
	{
	 "Username" = {username},
	 "Password" = {password
	}

	1.3) Update user data [users acces only]
	*/{id} [HttpPut]*
	**BODY:**
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

	1.4) Get all users [users acces only]
	*/ [HttpGet]*

	1.5) Get user by id [users acces only]
	*/{id} [HttpGet]*

	1.6) Delete user with id=? [users acces only]
	*/{id} [HttpDelete]*

	
<h4>2)ScheduleController</h4>
<h4>Route: https://localhost:44337/api/Schedule/{Method}</h4>

	Methods:

	2.1) Create new schedule [users acces only]
	*/Create [HttpPost]*
	
	**HEADERS:**
	Key: id Vaule: {id of user}

	**BODY:** (if closed on a given day set opening and closeing to <b>null</b>)
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

	2.2) Get schedule of given user [guest]
	*/{id} [HttpGet] *

	2.3) Remove schedule of given user [users acces only]
	*/{id} [HttpDelete]*

	2.4) Update schedule of given user
	*/{id} [HttpPut]*

	**BODY:**
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
	
