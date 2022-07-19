CREATE PROCEDURE [dbo].[GetMovies]
AS

select m.Name, g.Name from Movie as m
join Genres as g on g.Id = m.GenreId;
