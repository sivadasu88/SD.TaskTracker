CREATE TABLE IF NOT EXISTS public."Feature"
(
    "Id" uuid NOT NULL,
    "FeatureName" character varying COLLATE pg_catalog."default" NOT NULL,
    "FeatureDescription" character varying COLLATE pg_catalog."default" NOT NULL,
    "ProjectID" int,
      "SprintID" int,
     "Tags" character varying COLLATE pg_catalog."default" NOT NULL,
     "RankID" character varying COLLATE pg_catalog."default" NOT NULL,
      "FeatureOwnerID" character varying COLLATE pg_catalog."default" NOT NULL,
	"IsDeleted" boolean NOT NULL DEFAULT false,
	"CreatedBy" varchar,
    "CreatedTimeStamp" timestamp without time zone default (now() at time zone 'utc'),
    "LastModifiedBy" varchar,
    "LastModifiedTimeStamp" timestamp without time zone,
    CONSTRAINT "Feature_PKey" PRIMARY KEY ("Id"),
    CONSTRAINT "Feature_UKey" UNIQUE ("FeatureName")
)