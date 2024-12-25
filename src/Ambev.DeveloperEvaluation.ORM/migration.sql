CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

CREATE TABLE IF NOT EXISTS "Users" (
    "Id" UUID NOT NULL DEFAULT gen_random_uuid(),
    "Username" VARCHAR(50) NOT NULL,
    "Email" VARCHAR(100) NOT NULL,
    "Phone" VARCHAR(20) NOT NULL,
    "Password" VARCHAR(100) NOT NULL,
    "Status" VARCHAR(20) NOT NULL,
    "Role" VARCHAR(20) NOT NULL,
    "CreatedAt" TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    "UpdatedAt" TIMESTAMP WITHOUT TIME ZONE,
    CONSTRAINT "PK_Users" PRIMARY KEY ("Id")
);