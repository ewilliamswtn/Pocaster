# Podcaster

Do you listen to too many podcasts? Have you accrued several hundred Favorites on your go-to podcast listening app, thereby rendering the Favorite button useless? Have you written a small novel in Evernote trying to keep track of which podcasts you would like to revisit, and the topics discussed in each one? **Podcaster** is the answer to your problems

## Project Goals
- Store a list of favorite podcasts episodes
- Individual podcast episodes are stored in the following format:

   **Podcast Name**: *Episode Name*

  e.g., **The Joe Rogan Experience:** *#804 - Sam Harris*
  
- Each podcast episode can be tagged with topics, genres etc.
- Utilize a search feature that will search all episodes based on the **Podcast Name**, the **Episode Name**, or any associated **Tags**

## Technologies
Podcaster is an ASP.NET Core MVC app using an SQLite database, and is written in C#. It also uses JavaScript and jQuery for the search feature, as well as Razor syntax for the web page views.
