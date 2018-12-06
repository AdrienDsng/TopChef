CREATE TABLE sql.topchef.recipe_resource
(
    id int PRIMARY KEY NOT NULL IDENTITY,
    id_resource int,
    id_recipe int,
    quantity int,
    CONSTRAINT recipe_resource_resources_id_fk FOREIGN KEY (id_resource) REFERENCES sql.topchef.resources (id),
    CONSTRAINT recipe_resource_recipes_id_fk FOREIGN KEY (id_recipe) REFERENCES sql.topchef.recipes (id)
);
CREATE TABLE sql.topchef.recipes
(
    id int PRIMARY KEY NOT NULL IDENTITY,
    name text,
    nb_people int,
    type int
);
CREATE TABLE sql.topchef.resources
(
    id int PRIMARY KEY NOT NULL IDENTITY,
    name text
);
CREATE TABLE sql.topchef.step_tool
(
    id int PRIMARY KEY NOT NULL IDENTITY,
    id_step int,
    id_tool int,
    quantity int,
    CONSTRAINT step_tool_steps_id_fk FOREIGN KEY (id_step) REFERENCES sql.topchef.steps (id),
    CONSTRAINT step_tool_tools_id_fk FOREIGN KEY (id_tool) REFERENCES sql.topchef.tools (id)
);
CREATE TABLE sql.topchef.steps
(
    id int PRIMARY KEY NOT NULL IDENTITY,
    id_recipe int,
    wait_time int,
    step_number int,
    sync int,
    CONSTRAINT steps_recipes_id_fk FOREIGN KEY (id_recipe) REFERENCES sql.topchef.recipes (id)
);
CREATE TABLE sql.topchef.stock
(
    id int PRIMARY KEY NOT NULL IDENTITY,
    id_resource int,
    quantity int,
    place int,
    arrived_at datetime,
    CONSTRAINT id_resource FOREIGN KEY (id_resource) REFERENCES sql.topchef.resources (id)
);
CREATE TABLE sql.topchef.tools
(
    id int PRIMARY KEY NOT NULL IDENTITY,
    name text
);