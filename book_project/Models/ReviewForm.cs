using Microsoft.AspNetCore.Mvc.RazorPages;


public class ReviewForm : PageModel {
    public int rating {get; set;}
    public string analysis {get; set;}

    public void OnGet() {

    }

    public void OnPostSubmit(IFormCollection form) {
        this.rating = int.Parse(form["rating"].ToString());
        this.analysis = form["analysis"].ToString();

        Console.WriteLine(rating);
        Console.WriteLine(analysis);
    }
}