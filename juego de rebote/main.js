//JCGE 02/10/2016: Juego de esquivar




// Initialize Phaser and creates a game
var game = new Phaser.Game(400, 600, Phaser.AUTO, 'gameDiv');
//variables de personajes
var player, fondo, collisiones = 0, text, enemigos;
//variables de control
var direccion = true, backgroundv;
// Creates a new 'main' state that will contain the game
var mainState =
{
  // Function for loading all assets of the game (called only once)
  preload: function()
  {
    //precargamos la imagen del mono
    game.load.image('fondo','assets/calle.png');
    game.load.image('player','assets/carro-b.png');
    game.load.image('enemigo','assets/carro-a.png');
  },
  // Fuction called o after 'preload' to setup the game (called only once)
  create: function()
  {
    //dibujamos al mono y el fondo
    fondo   = game.add.tileSprite(0,0,400,600,'fondo');
    player  = game.add.sprite(game.world.centerX,game.world.centerY + 185,'player');

    //Es la lista de enemigos con gravedad
    this.enemigos = game.add.physicsGroup();

    // La gravedad, la utilizaremos para el mono
    game.physics.startSystem(Phaser.Physics.ARCADE);
    game.physics.arcade.enable(player);

    //Esto hace que se quede pegado en el muro OMG!!
    player.body.collideWorldBounds = true;

    //onTap evalua un tap a la pantalla
    game.input.onTap.add(this.onTap,this);

    //Velocidad del fondo
    backgroundv = 10;

    //Esta funcion cada 2000 milisegundos hace la funcion en sus parametros
    this.timer = game.time.events.loop(2000, this.newWave, this);

    //Este es el UI de el contador de enemigos creados
    this.score = 0;
    this.labelScore = game.add.text(20, 20, "0", { font: "30px Arial", fill: "#ffffff" });
  },
  // This function is called 60 times per second
  update: function()
  {
    //Cada vez que se tocan ejecuta la funcion
    game.physics.arcade.overlap(player, this.enemigos, this.restartGame, null, this);

    //Cada tiempo se mueve el fondo
    fondo.tilePosition.y += backgroundv;

    //Esto hace que se mueva el personaje
    if (direccion == true)
    {
      player.body.velocity.x = 250;
    }
    else
    {
      player.body.velocity.x = -250;
    }
  },
  onTap: function()
  {
    if (direccion == true)
    {
      direccion = false;
    }
    else
    {
      direccion = true;
    }
  },
  restartGame: function()
  {
    game.state.start('main');
  },
  //Esta funcion Agrega 1 enemigo
  addOneEnemigo: function(x, y)
  {
    var enemigo = game.add.sprite(x, y, 'enemigo');
    this.enemigos.add(enemigo);
    game.physics.arcade.enable(enemigo);
    enemigo.body.velocity.y = 200;
    enemigo.checkWorldBounds = true;
    enemigo.outOfBoundsKill = true;
  },
  //Esta crea un enemigo y lo agrega al conteo
  newWave: function()
  {
    var x = Math.floor(Math.random() * 399) + 1;
    this.addOneEnemigo(x, -100);
    this.score += 1;
    this.labelScore.text = this.score;
  }
};

//Add and start the 'main' state to start the game
game.state.add('main', mainState);
game.state.start('main');