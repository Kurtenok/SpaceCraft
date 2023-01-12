# SpaceCraft

RU:
Руководство Пользователя
Пока проект представляет из себя скорее заготовку чем реальную игру, поэтому имеется два вида управнения игроком. Первое-это используя джойстик(предпологается игра на телефоне), где игрок может упралять вручную как движением, так и стрельбой. Второй вариант предпологает использование компъютера и сделан как в обычных стратегиях.

Далее о настройке кораблей:
Каждый корабль имеет на себе скрипт "HP Controller", который отвечает за живучесть. В нем можно настроить прочность щита, корпуса, эфекты при попадании, низком здоровъе и уничтожении, также в нём надо назначить UI елементы, отвечающие за отображение показателей жизни

Вооружение
К любому кораблю можно добавить вооружение в виде турелей. Их в игре два вида - пулеметные и ракетные. Пулеметы можно настроить следующим образом: указать точность стрельбы, скорость пули, наносимый урон, скорость вращения турели, скоростельность, максмимальный и минимальный угол поворота. Ракетные характеризуються только уроном, поскольку они не ограничены в углах поворота.

Враги
Враги представлены в игре пока в двух видах - легкие и тяжелые фрегаты, но чтобы добавить нового надо всего лишь поставить скрипт "HP Controller", NavMeshAgent,RigitBody(все это можно скопировать с других кораблей), настроить колайдеры и расставить турели. За появление врагов отвечает скрипт Spawner, который прикреплен к пустому объекту, называемый "Spanwers". В нем можно настроить радиус появления врагов, и волны их появления. В каждой волне надо указать тип противника, количество и время появления после прошлой волны. Сами враги появляються случайным образом возле объекта, который удочерен к Spawners.

EN:
User's manual
While the project is a blank than a real game, so there are two types of player control. The first is using a joystick (assumed to be played on a phone), where the player can manually control movement and shooting. The second option involves the use of a computer and is done as in casual strategies.

More about setting up ships:
Each ship has an "HP Controller" script, which is responsible for survivability. In it, you can adjust the health of the shield, hull, effects on hit, low health and dead body of the ship, you also need to assign UI elements in it that are responsible for displaying health indicators

Armament
You can add turrets to any ship. There are two types of them in the game - machine gun and rockets launchers. Machine guns can be configured as follows: specify the accuracy of fire, bullet speed, damage dealt, turret rotation speed, fire rate, maximum and minimum rotation angle. Missiles are characterized only by damage, since they are not limited in the angles of rotation.

Enemies
Enemies are presented in the game in two types - light and heavy frigates, but in order to create a new one, you just need to attach the script "HP Controller", NavMeshAgent, RigitBody (all this can be copied from other ships), set up colliders and place turrets. The Spawner script, which is attached to an empty object,called "Spawners", on the scnene, is responsible for the appearance of enemies. In it, you can adjust the radius of the appearance of enemies, and the waves of their appearance. In each wave, you must specify the type of enemy, quantity and time of appearance after the last wave. The enemies appears randomly near the object that is attached to "Spawners".
