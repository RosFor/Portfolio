Use SamHotelDB;
Go

--Query 1
--Returns reservations that end in July 2023, with: GuestName, Room number(s), and ResDates.
--Search Result (Expect: 4 - Me, Walter, Wilfred, Bettyann) (Actual: TRUE)
Select
	RoomReservation.RoomNumber,
	Guest.FirstName,
	Guest.LastName,
	Reservation.StartDate,
	Reservation.EndDate
From RoomReservation
Inner Join Reservation on RoomReservation.ReservationID = Reservation.ReservationID
Inner Join Guest on Reservation.GuestID = Guest.GuestID
Where Reservation.EndDate Between '2023-07-01' And '2023-07-31'
Order By RoomReservation.RoomNumber Asc;
--~~~End~~~~~

--Query 2
--Returns list of all reservations for rooms with a jacuzzi, with: GuestName, RoomNumber, and ResDates.
--Search Result (Expect: 11)
--(201 Karie, 203 Bettyann & Karie, 205 Me, 207 Wilfred)
--(301 Walter & Mack, 303 Bettyann, 305 Duane & Bettyann, 307 Me) 
--(Actual: TRUE)
Select
	RoomReservation.RoomNumber,
	Guest.FirstName,
	Guest.LastName,
	Reservation.StartDate,
	Reservation.EndDate,
	Amenities.AmenityType
From RoomReservation
Inner Join Reservation on RoomReservation.ReservationID = Reservation.ReservationID
Inner Join Guest on Reservation.GuestID = Guest.GuestID
Inner Join Room on RoomReservation.RoomNumber = Room.RoomNumber
Inner Join RoomAmenities on Room.RoomNumber = RoomAmenities.RoomNumber
Inner Join Amenities on RoomAmenities.AmenityID = Amenities.AmenityID
Where Amenities.AmenityID = 3
Order By RoomReservation.RoomNumber Asc;
--~~~End~~~~~

--Query 3
--Returns all the rooms reserved for a specific guest, with: 
--GuestName, Room(s) reserved, StartDate, and # people in the reservation.
--(Choose a guest's name from the existing data.)
--Search Result (Expect: 205 & 307 'Sam Miller') (Actual: TRUE)
Select
	RR.RoomNumber,
	Concat(G.FirstName, ' ', G.LastName) GuestName,
	R.Adults,
	R.Children,
	R.StartDate,
	R.EndDate
From RoomReservation RR
Inner Join Reservation R on RR.ReservationID = R.ReservationID
Inner Join Guest G on R.GuestID = G.GuestID
Where G.GuestID = 1
Order By R.StartDate
--~~~End~~~~~

--Query 4
--Returns a list of Rooms, ResID, cost per-room for each reservation.
--The results should include all rooms, whether or not there is a reservation.
--Search Result (Expect: ??) (Actual: 26, with 2 NULL reservations)
Select
	R.RoomNumber,
	RR.ReservationID,
	RT.BasePrice,
	Res.TotalRoomCost
From Room R
Full Outer Join RoomReservation RR on R.RoomNumber = RR.RoomNumber
Full Outer Join RoomType RT on R.RoomTypeID = RT.RoomTypeID
Full Outer Join Reservation Res on RR.ReservationID = Res.ReservationID
--~~~End~~~~~

--Query 5
--Returns all the rooms accommodating at least three guests, and that are reserved on any date in April 2023
----Search Result (Expect: ??)
----(Actual: 0)
Select
	R.RoomNumber,
	Sum(Res.Adults + Res.Children) TotalGuests,
	Res.StartDate,
	Res.EndDate
From Room R
Inner Join RoomReservation RR on R.RoomNumber = RR.RoomNumber
Inner Join Reservation Res on RR.ReservationID = Res.ReservationID
WHERE (Month(StartDate) Like 04
OR Month(EndDate) Like 04)
And (Year(StartDate) Like 2023
And Year(EndDate) Like 2023)
Group By R.RoomNumber, Res.StartDate, Res.EndDate
Having Sum(Res.Adults + Res.Children) >= 3
Order by Res.StartDate Asc

--SELECT 
--	R.RoomNumber,
--	SUM(Res.Adults + Res.Children) TotalGuest,
--	Res.StartDate,
--	Res.EndDAte
--FROM Room R
--JOIN RoomReservation RR on R.RoomNumber = RR.RoomNumber
--JOIN Reservation Res on RR.ReservationID = Res.ReservationID
--WHERE ((Res.StartDate BETWEEN '2023-04-01' AND '2023-04-30')
--	OR (Res.EndDate BETWEEN '2023-04-01' AND '2023-04-30'))
--	--AND (Res.Adults + Res.Children) >= 3)
--GROUP BY R.RoomNumber, Res.StartDate, Res.EndDate
--HAVING SUM(Res.Adults + Res.Children) >= 1


--~~~End~~~~~

--Query 6
--Returns a list of all guest names and the number of reservations per guest.
--Sort, starting with the guest with the most reservations and then by the guest's last name.
--Search Result (Expect: 11)
--(Zachery - 1)
--(Aurore - 2, Duane 2, Joleen - 2, Karie - 2, Maritza - 2, Walter - 2, Wilfred - 2, Me - 2)
--(Bettyann - 3, Mack - 4)
--(Actual: TRUE)
Select
	G.LastName,
	G.FirstName,
	Count(R.ReservationID) TotalReservations
From Guest G
Inner Join Reservation R on G.GuestID = R.GuestID
Group By G.LastName, G.FirstName
Order By Count(R.ReservationID) Desc, G.LastName Asc
--~~~End~~~~~

--Query 7
--Write a query that displays the name, address, and phone number of a guest based on their phone number. (Choose a phone number from the existing data.)
--Search Result (Expect: 1, Maritza Tilton) (Actual: TRUE) 
Select
	Concat(G.FirstName, ' ', G.LastName) GuestName,
	G.[Address],
	G.Phone
From Guest G
Where G.Phone = '446.351.6860'
--~~~End~~~~~
