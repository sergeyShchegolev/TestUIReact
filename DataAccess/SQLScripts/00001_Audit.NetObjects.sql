--go
--if schema_id('app') is null
--    exec ('create schema [app]')
--go
--drop view if exists [app].[v_Events]
--go
--drop table if exists [app].[Events]
--go


CREATE TABLE app.events
(
    id bigserial NOT NULL,
    inserted_date timestamp without time zone NOT NULL DEFAULT now(),
    updated_date timestamp without time zone NOT NULL DEFAULT now(),
    data jsonb NOT NULL,
    event_type varchar(500),
    "user" varchar(500) NULL,
    "machine" varchar(500) NULL,
    CONSTRAINT event_pkey PRIMARY KEY (id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

--drop view if exists [app].[v_Events]
--go
--CREATE VIEW [app].[v_Events] WITH SCHEMABINDING
--AS
--SELECT EventId, 
--    InsertedDate,
--    CAST(JSON_VALUE(JsonData, '$.EventType') AS NVARCHAR(255)) AS [EventType],
--    CAST(JSON_VALUE(JsonData, '$.ReferenceId') AS NVARCHAR(255)) AS [ReferenceId],
--    JSON_VALUE(JsonData, '$.Target.Type') As [TargetType],
--    COALESCE(JSON_VALUE(JsonData, '$.Target.Old'), JSON_QUERY(JsonData, '$.Target.Old')) AS [TargetOld],
--    COALESCE(JSON_VALUE(JsonData, '$.Target.New'), JSON_QUERY(JsonData, '$.Target.New')) AS [TargetNew],
--    JSON_QUERY(JsonData, '$.Comments') AS [Comments],
--    [JsonData],
--	[User],
--	[Machine]
--FROM [app].[Events]
--GO

--CREATE UNIQUE CLUSTERED INDEX PK_V_EVENTS ON [app].[v_Events] (EventId)
--GO
--CREATE INDEX IX_V_EVENTS_EventType_ReferenceId ON [app].[v_Events] (EventType, ReferenceId)
--GO
