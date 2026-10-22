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
//Game is more responsible for the ISystem type stuff 
 
//maybe use assetmanager to manage mesh, texture.   use shadermanager to manage shader.
//need to fix ordering of systems in game loop. Eg have to shutdown renderer before window. maybe have a system manager that manages the systems and their order.

//renderer gets render data from world. renderer.Render(World, Camera) renderer changes projection(each OnResize) and view(each frame) //Renderer owns shaderManager
//maybe make material later on with with shader in it that you create with a reference to renderer.ShaderManager. Then you can create a renderable with a mesh and material.