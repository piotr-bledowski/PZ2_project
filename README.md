# PZ2_project
Final project for .NET course at AGH UST

The application allows users to review books available in the library.

There are 3 main views:
- the homepage containing personal recommendations described in more detail below
- the "Books" page containing a list of all the books available to review
- the "Reviews" page for a particular book displaying the review interface

Homepage and Books views are generally passive and allow for little interaction, only navigating to either of the remaining views,
whereas the Reviews view allows for adding a book to favorites, removing it from that list, creating and deleting reviews.

Users can keep a favorites list based on which they will get recommendations on the homepage.
The recommendations are books of user's favorite authors that they don't have on their favorites list yet.

There is a full REST API for all the models, however there is no authorization system and it is accessible by simply going to a corresponding endpoint address
with no auth whatsoever.

