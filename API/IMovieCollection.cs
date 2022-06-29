using System;

// invariant: no duplicates in this movie collection
public interface IMovieCollection
{
	// get the number of (different) movies in this movie collection
	int Number 
	{
		get;
	}

	// Check if this movie collection is empty
	bool IsEmpty();

	// Insert a movie into this movie collection
	bool Insert(IMovie movie);

	// Delete a movie from this movie collection
	bool Delete(IMovie movie);

	// Search for a movie in this movie collection
	bool Search(IMovie movie);

	// Search for a movie by its title in this movie collection  
	public IMovie Search(string title);

	// Store all the movies in this movie collection in an array in the dictionary order by their titles
	IMovie[] ToArray();

	// Clear this movie collection
	void Clear();
}

