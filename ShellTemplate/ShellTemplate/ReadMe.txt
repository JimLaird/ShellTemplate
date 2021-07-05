Welcome to my App ShellTemplate. Here are some tips for building your app!

---------
TODO List
---------
Fingerprint / Face Recognition / Biometric Authentication
Splash Screen in Android
Splash Screen in iOS
-------------------------------------------------------------------------------

----------------
REVISION HISTORY
----------------


17 June 2021 - Initial Commit
-----------------------------

Your App Shell
--------------
This template uses Shell, an app container that reduces the complexity of your apps by providing 
fundamental features including:

- A single place to describe the app's visual hierarchy.
- Common navigation such as a flyout menu and tabs.
- A URI-based navigation scheme that permits navigation to any page in the application.
- An integrated search handler.

Open AppShell.xaml to begin exploring. To learn more about Shell 
visit: https://docs.microsoft.com/xamarin/xamarin-forms/app-fundamentals/shell/introduction
-------------------------------------------------------------------------------


Database Name
-------------
First things first.  Open Config/Constants.cs and change the name of the database file, otherwise the
app will use the default name and you could end up accidentally sharing data between apps.
-------------------------------------------------------------------------------


MVVM
----
This template uses the MVVM built into xamarin, feel free to use the MVVM framework of your choice
I like the built in stuff as it has simple URI based navigation though.  If you add more pages to your
app, then remember to add them to AppShel.xaml.cs under Register Routes section
-------------------------------------------------------------------------------


APP Theme Binding
-----------------
I've built this to use app theme binding by default.  see the settings page to switch 
between app themes or the system default.  You can also change the theme colors by 
modifying the color keys in the app.xaml file
-------------------------------------------------------------------------------


Login and Registration
----------------------
User details are stored in a local SQLite database.  Logins are validated, and registrations are 
checked against valid users.  If a user already exists, registration is aborted.
On successful log in, the User Id is stored using Xamarin Essentials Preferences for later use in the app.
Passwords are stored as plain text in this example.  In a production app, use OAuth or some other 
token based authentication scheme
-------------------------------------------------------------------------------


User Profile
------------
The user profile page allows the logged in user to add/edit their profile picture as well as changing their 
email address or password.  The profile picture if not set will display the users initials. 
Their name and profile picture will also appear in the header of the shell flyout page.
You have the option to select an image from the picture gallery or take a new photograph.
-------------------------------------------------------------------------------


Xamarin Community Toolkit
-------------------------
This project makes use of Xamarin Community Toolkit particularly for some of the control behaviours and converters, and
some of the content views, such as Avatar View etc.  Documentation for this is to be found at 
https://docs.microsoft.com/en-us/xamarin/community-toolkit/
-------------------------------------------------------------------------------