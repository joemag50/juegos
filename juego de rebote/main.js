// Initialize Phaser and creates a game
var game = new Phaser.Game(400, 600, Phaser.AUTO, 'gameDiv');

//variables de personajes
var player, enemigo, fondo;
//variables de control
var direccion = true, backgroundv, nueva_posicion;

// Creates a new 'main' state that will contain the game
var mainState =
{
    // Function for loading all assets of the game (called only once)
    preload: function()
    { 
        //precargamos la imagen del mono
        game.load.image('fondo','assets/fondo.png');
        game.load.image('player','assets/player.png');
        game.load.image('enemigo','assets/enemigo.png');
    },
    // Fuction called o after 'preload' to setup the game (called only once)
    create: function()
    {
        //dibujamos al mono
        fondo   = game.add.tileSprite(0,0,400,600,'fondo');
        player  = game.add.sprite(game.world.centerX,game.world.centerY + 200,'player');
        enemigo = game.add.sprite(10,0,'enemigo');
        
        // La gravedad, la utilizaremos para los objetos que caen
        game.physics.startSystem(Phaser.Physics.ARCADE);
        game.physics.arcade.enable([enemigo,player]);

        enemigo.body.gravity.y = 50;
        enemigo.body.velocity.y = 100;
        //Esto hace que se quede pegado en el muro OMG!!
        player.body.collideWorldBounds = true;

        //Funciones sobre movimiento
        //onTap evalua un tap o dobletap
        game.input.onTap.add(this.onTap,this);
        backgroundv = 2;  //Velocidad del fondo
    },
    // This function is called 60 times per second
    update: function()
    {
        fondo.tilePosition.y += backgroundv;
        
        if (direccion == true)
        {
            player.body.velocity.x = 250;
        }
        else
        {
            player.body.velocity.x = -250;
        }
        
        //movimiento
        
        nueva_posicion = Math.floor(Math.random() * 399) + 1;
        if (enemigo.y > 600)
        {
            enemigo.x = nueva_posicion;
            enemigo.y = 0;
            enemigo.body.velocity.y = 100;
        }
    },
    onTap: function(pointer, doubleTap)
    {
        if (!doubleTap)
        {
            direccion = (direccion === false) ? true : false;
        }
    }
};

//Add and start the 'main' state to start the game
game.state.add('main', mainState);
game.state.start('main');