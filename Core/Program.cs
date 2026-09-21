//To push first git / commit or stash Then enter message & commit All then:
//Force push commands // git push --force origin master
//Force pull commands // git fetch origin // git reset --hard origin/master
class Program
{
    static void Main()
    {
        Game game  = new Game();
        game.Run();
    } 
}



//structure plans 
//World is more responisble for the monobehaviour more type stuff 
//Game is more responsible for the ISystem type stuff     // follow more webgl project structure 