//JCGE 02/10/2016: Juego de esquivar

// Initialize Phaser and creates a game
var game = new Phaser.Game(window.screen.width, window.screen.height, Phaser.AUTO, 'gameDiv');
//variables de personajes
var player, fondo, collisiones = 0, text, enemigos, pause;
//variables de control
var direccion = true, backgroundv = 10;
// Creates a new 'main' state that will contain the game
var mainState =
{
  // Function for loading all assets of the game (called only once)
  preload: function()
  {
    //precargamos la imagen del mono
    game.load.image('fondo',  'assets/calle.png');
    game.load.image('player', 'assets/carro-b.png');
    game.load.image('enemigo','assets/carro-a.png');
    game.load.image('pause',  'assets/pause.png');
  },
  // Fuction called o after 'preload' to setup the game (called only once)
  create: function()
  {
    //dibujamos al mono y el fondo
    //hice un truco de acomodar siempre al centro de la pantalla, 400 es el tamaño original de la imagen porque si lo haces mas grande se empieza a repetir
    fondo  = game.add.tileSprite(game.world.centerX - 200, game.world.centerY - (window.screen.height/2), 400, window.screen.height,'fondo');
    pause  = game.add.button(350, 10, 'pause');
    player = game.add.sprite(game.world.centerX, game.world.centerY + 185, 'player');

    game.stage.backgroundColor = "008200"
    // La gravedad, la utilizaremos para el mono
    game.physics.startSystem(Phaser.Physics.ARCADE);
    game.physics.arcade.enable(player);

    //onTap evalua un tap a la pantalla
    game.input.onTap.add(this.onTap, this);
    
    //Es la lista de enemigos con gravedad
    this.enemigos = game.add.physicsGroup();

    //Esto hace que se quede pegado en el muro OMG!!
    player.body.collideWorldBounds = true;
    
    //Pausa
    pause.inputEnabled = true;
    pause.events.onInputUp.add(function() {game.paused = true});
    
    //despausa al dar click a la pantalla, Pausa en lugar de mandar traer una funcion, la hago aqui enseguida
    //posible bugg, donde da click tambien cambia de direccion
    game.input.onDown.add(unpause, self);
    function unpause(event)
    {
       if(game.paused)
       {
          game.paused = false;
       }
    }

    //Esta funcion cada 2000 milisegundos hace la funcion en sus parametros
    this.timer = game.time.events.loop(1000, this.newWave, this);

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
      player.body.velocity.x = 270;
    }
    else
    {
      player.body.velocity.x = -270;
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
    game.state.start('restartMenu');
  },
  //Esta funcion Agrega 1 enemigo cada tiempo que se determina arriba
  addOneEnemigo: function(x, y)
  {
    var enemigo = game.add.sprite(x, y, 'enemigo');
    this.enemigos.add(enemigo);
    game.physics.arcade.enable(enemigo);
    var ran_velocity = Math.floor(Math.random() * 399) + 200;
    enemigo.body.velocity.y = ran_velocity;
    enemigo.checkWorldBounds = true;
    enemigo.outOfBoundsKill = true;
    this.score += 1;
    this.labelScore.text = this.score;
  },
  //Esta crea un enemigo y lo agrega al conteo
  newWave: function()
  {
    var x = Math.floor(Math.random() * 399) + 1;
    this.addOneEnemigo(x, -100);
  },
  togglePause: function()
  {
    game.paused = true;
  }
};

var mainMenu =
{
  // Function for loading all assets of the game (called only once)
  preload: function()
  {
    game.load.image('menu',  'assets/menu.png');
    game.load.image('titulo','assets/titulo.png');
    game.load.image('boton', 'assets/boton.png');
  },
  // Fuction called o after 'preload' to setup the game (called only once)
  create: function()
  {
    var menu  = game.add.tileSprite(game.world.centerX - 200, game.world.centerY - (window.screen.height/2), 400, window.screen.height,'menu');
    var titulo = game.add.sprite(20,50,'titulo');
    var boton  = game.add.button(20, 400, 'boton', this.onTap, this);

    boton.onInputUp.add(this.onTap,this);
  },
  // This function is called 60 times per second
  update: function()
  {
  },
  onTap: function()
  {
    game.state.start('main');
  }
};

var restartMenu =
{
  // Function for loading all assets of the game (called only once)
  preload: function()
  {
    game.load.image('fondo','assets/calle.png');
    game.load.image('titulo','assets/titulo.png');
    game.load.image('boton', 'assets/bt_again.png');
  },
  // Fuction called o after 'preload' to setup the game (called only once)
  create: function()
  {
    fondo  = game.add.tileSprite(0, 0, 400, window.screen.height,'fondo');
    var boton  = game.add.button(20, 400, 'boton', this.onTap, this);
    var titulo = game.add.sprite(20,50,'titulo');

    boton.onInputUp.add(this.onTap,this);
  },
  // This function is called 60 times per second
  update: function()
  {
    fondo.tilePosition.y += backgroundv;
  },
  onTap: function()
  {
    game.state.start('main');
  }
};

var preload =
{
  // Function for loading all assets of the game (called only once)
  preload: function()
  {

  },
  // Fuction called o after 'preload' to setup the game (called only once)
  create: function()
  {

  },
  // This function is called 60 times per second
  update: function()
  {

  }
};

game.state.add('menu', mainMenu); 
game.state.add('restartMenu', restartMenu);
game.state.add('main', mainState);
game.state.start('menu');
//Add and start the 'main' state to start the game