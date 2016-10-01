// Initialize Phaser and creates a game
var game = new Phaser.Game(400, 600, Phaser.AUTO, 'gameDiv');

var player, enemigo, muro2;
var direccion = true;
var nueva_posicion;

// Creates a new 'main' state that will contain the game
var mainState = {

    // Function for loading all assets of the game (called only once)
    preload: function() { 
        //precargamos la imagen del mono
        game.load.image('player','assets/player.png');
        game.load.image('enemigo','assets/enemigo.png');
        game.load.image('muro','assets/muro.png');
    },

    // Fuction called o after 'preload' to setup the game (called only once)
    create: function() {
        //dibujamos al mono
        player  = game.add.sprite(200,500,'player');
        enemigo = game.add.sprite(10,0,'enemigo');
        muro    = game.add.sprite(380,500,'muro');
        muro2   = game.add.sprite(-50,500,'muro');

        // La gravedad, la utilizaremos para los objetos que caen
        game.physics.startSystem(Phaser.Physics.ARCADE);
        
        game.physics.arcade.enable(enemigo);
        enemigo.body.gravity.y = 50;
        enemigo.body.velocity.y = 100;

        //funcion del movimiento
        game.input.onDown.add(this.muevete,this);
    },

    // This function is called 60 times per second
    update: function() {
    	
    	if (player.x > 360){
    		direccion = false;
    	}
    	else if (player.x < 15){
    		direccion = true;
    	}

    	//movimiento
        if (direccion == true) {
            player.x = player.x + 4;
        }
        else if (direccion == false) {
            player.x = player.x - 4;
    	}
    	else{
    		player.x = player.x;
    	}

        nueva_posicion = Math.floor(Math.random() * 399) + 1;
        if (enemigo.y > 600){
        	enemigo.x = nueva_posicion;
        	enemigo.y = 0;
            enemigo.body.velocity.y = 100;
        }
    },
    muevete: function() {
        if (direccion == true){
            direccion = false;
        }
        else{
            direccion = true;
        }
    }
};

//Add and start the 'main' state to start the game
game.state.add('main', mainState);
game.state.start('main');