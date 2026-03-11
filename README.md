# Particulas

En este proyecto he creado un sistema de partículas sin usar el Particle System de Unity. Todo está hecho por código. Cada partícula se mueve siguiendo un tiro parabólico usando las fórmulas básicas de física.

He hecho dos scripts "Particula" y "ControlPaticulas".

Particula.cs, que controla una partícula individual (su velocidad, ángulo, tiempo de vida, gravedad y movimiento).Cuando la partícula se inicia, guardo su posición de salida y a partir de ahí se va calculando su movimiento usando las fórmulas del tiro parabólico. Básicamente, en cada frame se actualiza su posición en X y en Y según el tiempo que lleva viva.

ControlParticulas.cs, que se encarga de crear varias partículas cuando se pulsa la barra espaciadora, darles valores aleatorios para que no sean todas iguales y actualizar su movimiento cada frame. Cuando una partícula supera su tiempo de vida se elimina.

El resultado es una pequeña explosión de partículas que salen disparadas desde un punto y siguen una trayectoria parabólica hasta desaparecer y destruirse.
