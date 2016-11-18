//JCGE 02/10/2016: Juego de esquivar
//Iniciamos el canvas
var game = new Phaser.Game((window.innerWidth * window.devicePixelRatio), (window.innerHeight * window.devicePixelRatio), Phaser.CANVAS, 'gameDiv');
//variables globales de juego
var player, fondo, collisiones = 0, text, enemigos, pause;
//variables globales de control
var direccion = true, backgroundv = 10;
// mainState es el estado del juego
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
    fondo  = game.add.tileSprite(game.world.centerX-200, 0, 400, (window.innerHeight*2), 'fondo');
    pause  = game.add.button((game.world.centerX*2)-50, 10, 'pause');
    player = game.add.sprite(50, ((game.world.centerY * 2) - 175), 'player');
    //Estas llamadas son para que quepa en varios dispositivos
    this.scale.scaleMode = Phaser.ScaleManager.SHOW_ALL;
    this.scale.minWidth = 0;
    this.scale.minHeight = 0;
    this.scale.maxWidth = window.innerWidth;
    this.scale.maxHeight = window.innerHeight;
    game.scale.refresh();
    //Trucaso donde si se sale la imagen, la rellenamos con el color de la imagen
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
    //Boton Pausa
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
    //Esta funcion cada 1000 milisegundos hace la funcion en sus parametros
    this.timer = game.time.events.loop(1000, this.newWave, this);
    //Este es el UI de el contador de enemigos creados (Como guardamos el record??)
    this.score = 0;
    this.labelScore = game.add.text(20, 30, "0", { font: "40px Arial", fill: "#ffffff" });
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
    var x = Math.floor(Math.random() * (window.innerWidth* window.devicePixelRatio))+1;
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
    var menu   = game.add.tileSprite(0, 0, window.innerWidth*2, (window.innerHeight*2), 'menu');
    var titulo = game.add.sprite(game.world.centerX - 182,100,'titulo');
    var boton  = game.add.button(game.world.centerX - 182, ((game.world.centerY * 2) - 175), 'boton', this.onTap, this);
    this.scale.scaleMode = Phaser.ScaleManager.SHOW_ALL;
    this.scale.minWidth = 0;
    this.scale.minHeight = 0;
    this.scale.maxWidth = window.innerWidth;
    this.scale.maxHeight = window.innerHeight;    game.scale.refresh();
    boton.onInputUp.add(this.onTap,this);
  },
  // This function is called 60 times per second
  //La comentarize porque aun no hay nada movil en el menu principal
  //update: function()
  //{
  //},
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
    fondo  = game.add.tileSprite(game.world.centerX-200, 0, 400, (window.innerHeight*2), 'fondo');
    var boton  = game.add.button(game.world.centerX - 182, ((game.world.centerY * 2) - 175), 'boton', this.onTap, this);
    var titulo = game.add.sprite(game.world.centerX - 182,100,'titulo');
    //el boton de otravez o replay
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
console.log('I lead a muggle\'s life');
game.state.add('menu', mainMenu); 
game.state.add('restartMenu', restartMenu);
game.state.add('main', mainState);
game.state.start('menu');
//Add and start the 'main' state to start the game
// JCGE 16/11/2016: A veda y decian que no podia hacer jueguitos pendejos xD