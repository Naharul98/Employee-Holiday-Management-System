# Staff-Holiday-Management-System
An employee holiday management system, built for employees &amp; managers of an organization.

## Project Structure
The project consist of 3 different application, located in their respective directories
* Employee-App: A C# (WinForm) based desktop client application through which the employee can request a holiday.
* Employee-Website: An ASP.NET MVC based web application through which employees can also request a holiday.
* Manager-App: A C# (WinForm) based desktop client for managers of the organization.

## Features
### Manager-App
- User/Department/Role management
    - create/edit/delete employees/departments/roles.
    - Allocate an employee to a department and assign him/her a role.
- View a list of outstanding holiday requests
    - Approve/Reject holiday requests
- View a list of all holiday bookings and filter them by employee
- Select a date and show all employees working that day and those on leave that day.
- Visually depict in a calender form, which highlights the days on which an employee has booked leave.

### Employee-Website
- Submit a holiday request through the website
- View a list of existing holiday requests, which also shows whether they were approved/rejected
- Implements a REST Web Service (Used by the employee desktop client), which exposes functionality for login and submitting holiday request.

### Employee-App
- Offers the same functionality as the Employee website, however, it makes use of the REST Web service (Exposed by the web application) to perform its functions.

## Libraries used
- [Material Skin](https://github.com/IgnaceMaes/MaterialSkin)
