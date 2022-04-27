-- SCHEMA: FORFOOD

-- DROP SCHEMA IF EXISTS "FORFOOD" ;

CREATE SCHEMA IF NOT EXISTS "FORFOOD"
    AUTHORIZATION imnanxinwbzblu;
	

-- Table: FORFOOD.Products

-- DROP TABLE IF EXISTS "FORFOOD"."Products";

CREATE TABLE IF NOT EXISTS "FORFOOD"."Products"
(
    "IdProduct" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "Code" character varying(10) COLLATE pg_catalog."default" NOT NULL,
    "Name" character varying(50) COLLATE pg_catalog."default" NOT NULL,
    "Price" double precision NOT NULL,
    "Stock" integer NOT NULL,
    "Description" text COLLATE pg_catalog."default",
    "Image" text COLLATE pg_catalog."default",
    CONSTRAINT "Products_pkey" PRIMARY KEY ("IdProduct"),
    CONSTRAINT "Code" UNIQUE ("Code")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS "FORFOOD"."Products"
    OWNER to imnanxinwbzblu;


-- Table: FORFOOD.Users

-- DROP TABLE IF EXISTS "FORFOOD"."Users";

CREATE TABLE IF NOT EXISTS "FORFOOD"."Users"
(
    "IdUser" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "Name" character varying(50) COLLATE pg_catalog."default",
    "Lastname" character varying(50) COLLATE pg_catalog."default",
    "Email" character varying(20) COLLATE pg_catalog."default" NOT NULL,
    "Password" character varying(100) COLLATE pg_catalog."default" NOT NULL,
    "Role" integer NOT NULL,
    CONSTRAINT "Users_pkey" PRIMARY KEY ("IdUser"),
    CONSTRAINT pk_role FOREIGN KEY ("Role")
        REFERENCES "FORFOOD"."Role" ("IdRole") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS "FORFOOD"."Users"
    OWNER to imnanxinwbzblu;
	
	
-- Table: FORFOOD.Purchases

-- DROP TABLE IF EXISTS "FORFOOD"."Purchases";

CREATE TABLE IF NOT EXISTS "FORFOOD"."Purchases"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "Date" character varying(50) COLLATE pg_catalog."default",
    "Total" double precision,
    "IdUser" integer,
    "IdProduct" integer,
    "Cant" integer,
    CONSTRAINT "Users_Products_pkey" PRIMARY KEY ("Id"),
    CONSTRAINT "Users_PK" FOREIGN KEY ("IdUser")
        REFERENCES "FORFOOD"."Users" ("IdUser") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS "FORFOOD"."Purchases"
    OWNER to imnanxinwbzblu;
	
-- Table: FORFOOD.Role

-- DROP TABLE IF EXISTS "FORFOOD"."Role";

CREATE TABLE IF NOT EXISTS "FORFOOD"."Role"
(
    "IdRole" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "Name" character varying(20) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "Role_pkey" PRIMARY KEY ("IdRole")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS "FORFOOD"."Role"
    OWNER to imnanxinwbzblu;