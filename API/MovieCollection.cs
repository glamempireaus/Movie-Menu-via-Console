using System;

//A class that models a node of a binary search tree
//An instance of this class is a node in a binary search tree 
public class BTreeNode
{
	private IMovie movie; // movie
	private BTreeNode lchild; // reference to its left child 
	private BTreeNode rchild; // reference to its right child

	public BTreeNode(IMovie movie)
	{
		this.movie = movie;
		lchild = null;
		rchild = null;
	}

	public IMovie Movie
	{
		get { return movie; }
		set { movie = value; }
	}

	public BTreeNode LChild
	{
		get { return lchild; }
		set { lchild = value; }
	}

	public BTreeNode RChild
	{
		get { return rchild; }
		set { rchild = value; }
	}
}

// invariant: no duplicates in this movie collection
public class MovieCollection : IMovieCollection
{
	private BTreeNode root; // movies are stored in a binary search tree and the root of the binary search tree is 'root' 
	private int count; // the number of (different) movies currently stored in this movie collection 

	// get the number of movies in this movie colllection 
	public int Number { get { return count; } }

	// constructor - create an object of MovieCollection object
	public MovieCollection()
	{
		root = null;
		count = 0;	
	}

	// Check if this movie collection is empty
	public bool IsEmpty()
	{
		if (count == 0)
        {
			return true;
        }

		return false;
	}

	// Insert a movie into this movie collection
	public bool Insert(IMovie movie)
	{
		// check if parameter is null
		if (movie == null)
        {
			return false;
        }

		// check if root is null
		if (root == null || root.Movie == null)
        {
			root = new BTreeNode(movie);
        }
		else
        {
			BTreeNode currentNode = root;
			while (true)
			{
				// compare between current movie and movie to be inserted
				int compareTo = movie.CompareTo(currentNode.Movie);

				// check if duplicate
				if (compareTo == 0)
				{
					return false;
				}

				// check compareTo, and if empty, then insert
				if (compareTo == -1)
				{
					if (currentNode.LChild == null)
					{
						// insert if empty
						currentNode.LChild = new BTreeNode(movie);
						break;
					}
					else
					{
						// go down 1 depth
						currentNode = currentNode.LChild;
					}
				}
				else if (compareTo == 1)
				{
					if (currentNode.RChild == null)
					{
						// insert if empty
						currentNode.RChild = new BTreeNode(movie);
						break;
					}
					else
					{
						// go down 1 depth
						currentNode = currentNode.RChild;
					}
				}
			}
		}

		count++;
		return true;
	}

	// Delete a movie from this movie collection
	public bool Delete(IMovie movie)
	{
		// check if parameter is null
		if (movie == null)
		{
			return false;
		}

		// check if root is null
		if (root == null || root.Movie == null)
		{
			return false;
		}

		// initialise 
		BTreeNode currentNode = root;
		BTreeNode previousNode = currentNode;

		// find node to delete
		for (int i = 0; i < count; i++)
		{
			// check if node isn't inside tree
			if (currentNode == null)
            {
				return false;
            }

			// compare between current movie and movie to be inserted
			int compareTo = movie.CompareTo(currentNode.Movie);

			// go down 1 depth based on compare
			if (compareTo != 0)
            {
				previousNode = currentNode;

				if (compareTo == -1)
				{
					currentNode = currentNode.LChild;
				}
				else if (compareTo == 1)
				{
					currentNode = currentNode.RChild;
				}
			}
			else
            {
				// node found

				BTreeNode deleteNode = currentNode;

				// handle different cases
				if (deleteNode.LChild == null)
				{
					if (deleteNode.RChild == null)
					{
						// case 1: no children

						// special case: root has no children
						if (previousNode == deleteNode)
						{
							deleteNode.Movie = null;
							count--;
							return true;
						}

						// set previous node pointer to null
						if (previousNode.LChild == deleteNode)
                        {
							previousNode.LChild = null;
                        }
						else
                        {
							previousNode.RChild = null;
                        }
					}
					else
                    {
						// case 2: only rchild 

						// replace with rchild 
						deleteNode.Movie = deleteNode.RChild.Movie;
						deleteNode.LChild = deleteNode.RChild.LChild;
						deleteNode.RChild = deleteNode.RChild.RChild;
					}
				}
				else
                {
					if (deleteNode.RChild == null)
                    {
						// case 3: only lchild

						// replace with lchild
						deleteNode.Movie = deleteNode.LChild.Movie;
						deleteNode.RChild = deleteNode.LChild.RChild;
						deleteNode.LChild = deleteNode.LChild.LChild;

					}
					else
                    {
						// case 4: both children

						BTreeNode searchNode = deleteNode.RChild;
						BTreeNode previousSearchNode = deleteNode;

						// find predecessor to replace deletenode
						while (true)
						{
							if (searchNode.LChild != null)
                            {
								// go down an lchild and track previous searchnode
								previousSearchNode = searchNode;
								searchNode = searchNode.LChild;
                            }
							else
                            {
								// found predecessor
								break;
							}
                        }

						// after finding predecessor, start relinking pointers

						if (searchNode.RChild != null)
                        {
							if (previousSearchNode.LChild == searchNode)
							{
								previousSearchNode.LChild = searchNode.RChild;
							}
							else
							{
								previousSearchNode.RChild = searchNode.RChild;
							}
						}
						else
                        {
							if (previousSearchNode.LChild == searchNode)
                            {
								previousSearchNode.LChild = null;
							}
							else
							{
								previousSearchNode.RChild = null;
							}
						}

						// set deletenode to predecessornode
						deleteNode.Movie = searchNode.Movie;
					}
                }

				count--;
				return true;
			}
		}

		return false;
	}

	// Search for a movie in this movie collection
	public bool Search(IMovie movie)
	{
		// check if parameter is null
		if (movie == null)
		{
			return false;
		}

		// check if root is null
		if (this.root.Movie == null)
		{
			return false;
		}

		BTreeNode currentNode = root;
		for (int i = 0; i < count; i++)
		{
			// check if node not found
			if (currentNode == null)
			{
				return false;
			}

			// compare between current movie and movie to be inserted
			int compareTo = movie.CompareTo(currentNode.Movie);

			// check if node found
			if (compareTo == 0)
			{
				return true;
			}

			// go down 1 depth based on compare
			if (compareTo == -1)
			{
				currentNode = currentNode.LChild;
			}
			else if (compareTo == 1)
			{
				currentNode = currentNode.RChild;
			}
		}

		return false;
	}
	// Search for a movie by its title in this movie collection  
	public IMovie Search(string movietitle)
	{
		// check if parameter is null
		if (movietitle == null)
		{
			return null;
		}

		// check if root is null
		if (this.root.Movie == null)
		{
			return null;
		}

		BTreeNode currentNode = root;
		for (int i = 0; i < count; i++)
		{
			// check if node not found
			if (currentNode == null)
			{
				return null;
			}

			// compare between current movie and movie to be inserted
			int compareTo = movietitle.CompareTo(currentNode.Movie.Title);

			// check if node found
			if (compareTo == 0)
			{
				return currentNode.Movie;
			}

			// go down 1 depth based on compare
			if (compareTo == -1)
			{
				currentNode = currentNode.LChild;
			}
			else if (compareTo == 1)
			{
				currentNode = currentNode.RChild;
			}
		}

		return null;
	}

	// Store all the movies in this movie collection in an array in the dictionary order by their titles
	public IMovie[] ToArray()
	{
		int arrayCount = 0;
		IMovie[] constructedArray = new IMovie[count];

		if (count == 0)
        {
			return constructedArray;
		}

		bool recursiveSearch(BTreeNode node)
		{
			if (node.LChild != null)
			{
				recursiveSearch(node.LChild);
			}

			constructedArray[arrayCount] = node.Movie;
			arrayCount++;

			if (node.RChild != null)
			{
				recursiveSearch(node.RChild);
			}

			return false;
		}

		recursiveSearch(root);

		return constructedArray;
	}

	// Clear this movie collection
	public void Clear()
	{
		root.Movie = null;
		root.LChild = null;
		root.RChild = null;
	}
}





