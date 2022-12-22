PGDMP         0                z            MedWorking_20221130    14.5    14.5 �    �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    50922    MedWorking_20221130    DATABASE     y   CREATE DATABASE "MedWorking_20221130" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'English_United States.1252';
 %   DROP DATABASE "MedWorking_20221130";
                postgres    false                        2615    50923    hangfire    SCHEMA        CREATE SCHEMA hangfire;
    DROP SCHEMA hangfire;
                postgres    false            �            1259    50924    counter    TABLE     �   CREATE TABLE hangfire.counter (
    id bigint NOT NULL,
    key text NOT NULL,
    value bigint NOT NULL,
    expireat timestamp without time zone
);
    DROP TABLE hangfire.counter;
       hangfire         heap    postgres    false    4            �            1259    50929    counter_id_seq    SEQUENCE     y   CREATE SEQUENCE hangfire.counter_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 '   DROP SEQUENCE hangfire.counter_id_seq;
       hangfire          postgres    false    210    4            �           0    0    counter_id_seq    SEQUENCE OWNED BY     E   ALTER SEQUENCE hangfire.counter_id_seq OWNED BY hangfire.counter.id;
          hangfire          postgres    false    211            �            1259    50930    hash    TABLE     �   CREATE TABLE hangfire.hash (
    id bigint NOT NULL,
    key text NOT NULL,
    field text NOT NULL,
    value text,
    expireat timestamp without time zone,
    updatecount integer DEFAULT 0 NOT NULL
);
    DROP TABLE hangfire.hash;
       hangfire         heap    postgres    false    4            �            1259    50936    hash_id_seq    SEQUENCE     v   CREATE SEQUENCE hangfire.hash_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 $   DROP SEQUENCE hangfire.hash_id_seq;
       hangfire          postgres    false    4    212            �           0    0    hash_id_seq    SEQUENCE OWNED BY     ?   ALTER SEQUENCE hangfire.hash_id_seq OWNED BY hangfire.hash.id;
          hangfire          postgres    false    213            �            1259    50937    job    TABLE     '  CREATE TABLE hangfire.job (
    id bigint NOT NULL,
    stateid bigint,
    statename text,
    invocationdata text NOT NULL,
    arguments text NOT NULL,
    createdat timestamp without time zone NOT NULL,
    expireat timestamp without time zone,
    updatecount integer DEFAULT 0 NOT NULL
);
    DROP TABLE hangfire.job;
       hangfire         heap    postgres    false    4            �            1259    50943 
   job_id_seq    SEQUENCE     u   CREATE SEQUENCE hangfire.job_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 #   DROP SEQUENCE hangfire.job_id_seq;
       hangfire          postgres    false    214    4            �           0    0 
   job_id_seq    SEQUENCE OWNED BY     =   ALTER SEQUENCE hangfire.job_id_seq OWNED BY hangfire.job.id;
          hangfire          postgres    false    215            �            1259    50944    jobparameter    TABLE     �   CREATE TABLE hangfire.jobparameter (
    id bigint NOT NULL,
    jobid bigint NOT NULL,
    name text NOT NULL,
    value text,
    updatecount integer DEFAULT 0 NOT NULL
);
 "   DROP TABLE hangfire.jobparameter;
       hangfire         heap    postgres    false    4            �            1259    50950    jobparameter_id_seq    SEQUENCE     ~   CREATE SEQUENCE hangfire.jobparameter_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 ,   DROP SEQUENCE hangfire.jobparameter_id_seq;
       hangfire          postgres    false    216    4            �           0    0    jobparameter_id_seq    SEQUENCE OWNED BY     O   ALTER SEQUENCE hangfire.jobparameter_id_seq OWNED BY hangfire.jobparameter.id;
          hangfire          postgres    false    217            �            1259    50951    jobqueue    TABLE     �   CREATE TABLE hangfire.jobqueue (
    id bigint NOT NULL,
    jobid bigint NOT NULL,
    queue text NOT NULL,
    fetchedat timestamp without time zone,
    updatecount integer DEFAULT 0 NOT NULL
);
    DROP TABLE hangfire.jobqueue;
       hangfire         heap    postgres    false    4            �            1259    50957    jobqueue_id_seq    SEQUENCE     z   CREATE SEQUENCE hangfire.jobqueue_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE hangfire.jobqueue_id_seq;
       hangfire          postgres    false    218    4            �           0    0    jobqueue_id_seq    SEQUENCE OWNED BY     G   ALTER SEQUENCE hangfire.jobqueue_id_seq OWNED BY hangfire.jobqueue.id;
          hangfire          postgres    false    219            �            1259    50958    list    TABLE     �   CREATE TABLE hangfire.list (
    id bigint NOT NULL,
    key text NOT NULL,
    value text,
    expireat timestamp without time zone,
    updatecount integer DEFAULT 0 NOT NULL
);
    DROP TABLE hangfire.list;
       hangfire         heap    postgres    false    4            �            1259    50964    list_id_seq    SEQUENCE     v   CREATE SEQUENCE hangfire.list_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 $   DROP SEQUENCE hangfire.list_id_seq;
       hangfire          postgres    false    220    4            �           0    0    list_id_seq    SEQUENCE OWNED BY     ?   ALTER SEQUENCE hangfire.list_id_seq OWNED BY hangfire.list.id;
          hangfire          postgres    false    221            �            1259    50965    lock    TABLE     �   CREATE TABLE hangfire.lock (
    resource text NOT NULL,
    updatecount integer DEFAULT 0 NOT NULL,
    acquired timestamp without time zone
);
    DROP TABLE hangfire.lock;
       hangfire         heap    postgres    false    4            �            1259    50971    schema    TABLE     ?   CREATE TABLE hangfire.schema (
    version integer NOT NULL
);
    DROP TABLE hangfire.schema;
       hangfire         heap    postgres    false    4            �            1259    50974    server    TABLE     �   CREATE TABLE hangfire.server (
    id text NOT NULL,
    data text,
    lastheartbeat timestamp without time zone NOT NULL,
    updatecount integer DEFAULT 0 NOT NULL
);
    DROP TABLE hangfire.server;
       hangfire         heap    postgres    false    4            �            1259    50980    set    TABLE     �   CREATE TABLE hangfire.set (
    id bigint NOT NULL,
    key text NOT NULL,
    score double precision NOT NULL,
    value text NOT NULL,
    expireat timestamp without time zone,
    updatecount integer DEFAULT 0 NOT NULL
);
    DROP TABLE hangfire.set;
       hangfire         heap    postgres    false    4            �            1259    50986 
   set_id_seq    SEQUENCE     u   CREATE SEQUENCE hangfire.set_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 #   DROP SEQUENCE hangfire.set_id_seq;
       hangfire          postgres    false    225    4            �           0    0 
   set_id_seq    SEQUENCE OWNED BY     =   ALTER SEQUENCE hangfire.set_id_seq OWNED BY hangfire.set.id;
          hangfire          postgres    false    226            �            1259    50987    state    TABLE     �   CREATE TABLE hangfire.state (
    id bigint NOT NULL,
    jobid bigint NOT NULL,
    name text NOT NULL,
    reason text,
    createdat timestamp without time zone NOT NULL,
    data text,
    updatecount integer DEFAULT 0 NOT NULL
);
    DROP TABLE hangfire.state;
       hangfire         heap    postgres    false    4            �            1259    50993    state_id_seq    SEQUENCE     w   CREATE SEQUENCE hangfire.state_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 %   DROP SEQUENCE hangfire.state_id_seq;
       hangfire          postgres    false    4    227            �           0    0    state_id_seq    SEQUENCE OWNED BY     A   ALTER SEQUENCE hangfire.state_id_seq OWNED BY hangfire.state.id;
          hangfire          postgres    false    228            �            1259    50994    Accounts    TABLE       CREATE TABLE public."Accounts" (
    "UserId" uuid NOT NULL,
    "UserName" character varying(100),
    "PasswordHash" character varying(200),
    "EmployeeID" character varying(50),
    "Office" bigint,
    "Unit" bigint,
    "Position" bigint,
    "FullName" character varying(250),
    "Email" character varying(100),
    "SignatureUrl" character varying(500),
    "PhoneNumber" character varying(20),
    "Auto" boolean,
    "TimeLogin" time without time zone,
    "Online" boolean,
    "Level" integer,
    "HC" boolean,
    "Active" boolean,
    "AvatarUrl" character varying(500),
    "SerialNumber" character varying(50),
    "CreateUser" character varying(20),
    "CreateDate" timestamp with time zone,
    "UpdateUser" character varying(20),
    "UpdateDate" timestamp with time zone
);
    DROP TABLE public."Accounts";
       public         heap    postgres    false                       1259    51709    AdvisoryStaff    TABLE     �   CREATE TABLE public."AdvisoryStaff" (
    "Id" uuid NOT NULL,
    "DocId" uuid,
    "AdvisoryUserId" uuid,
    "AdvisoryUserName" character varying(100),
    "PositionName" character varying(250),
    "Status" boolean,
    "PositionId" bigint
);
 #   DROP TABLE public."AdvisoryStaff";
       public         heap    postgres    false            �            1259    50999    ApprovalGeneralDocumentProcess    TABLE     �  CREATE TABLE public."ApprovalGeneralDocumentProcess" (
    "Id" uuid NOT NULL,
    "GroupDocumentId" uuid,
    "TimeApplication" timestamp with time zone,
    "Description" character varying(500),
    "Active" boolean,
    "CreateDate" timestamp with time zone,
    "CreateUser" character varying(250),
    "UpdateDate" timestamp with time zone,
    "UpdateUser" character varying(250)
);
 4   DROP TABLE public."ApprovalGeneralDocumentProcess";
       public         heap    postgres    false            �            1259    51004 "   ApprovalGeneralDocumentProcessUnit    TABLE     �  CREATE TABLE public."ApprovalGeneralDocumentProcessUnit" (
    "Id" uuid NOT NULL,
    "ApplicableUnit" bigint,
    "GroupDocumentId" uuid,
    "TimeApplication" timestamp with time zone,
    "Description" character varying(500),
    "Active" boolean,
    "CreateDate" timestamp with time zone,
    "CreateUser" character varying(250),
    "UpdateDate" timestamp with time zone,
    "UpdateUser" character varying(250)
);
 8   DROP TABLE public."ApprovalGeneralDocumentProcessUnit";
       public         heap    postgres    false                       1259    51614    ApprovalOfficeLevel    TABLE     �   CREATE TABLE public."ApprovalOfficeLevel" (
    "Id" uuid NOT NULL,
    "ApprovalStepLevelId" uuid,
    "OfficeId" bigint,
    "OfficeName" character varying(250),
    "Status" boolean,
    "Level" integer
);
 )   DROP TABLE public."ApprovalOfficeLevel";
       public         heap    postgres    false                       1259    51629    ApprovalStaffLevel    TABLE       CREATE TABLE public."ApprovalStaffLevel" (
    "Id" uuid NOT NULL,
    "ApprovalOfficeLevelId" uuid,
    "ApprovalUserId" uuid,
    "ApprovalUserName" character varying(100),
    "PositionName" character varying(250),
    "Level" integer,
    "IsApproved" boolean
);
 (   DROP TABLE public."ApprovalStaffLevel";
       public         heap    postgres    false                       1259    51594    ApprovalStepLevel    TABLE     �   CREATE TABLE public."ApprovalStepLevel" (
    "Id" uuid NOT NULL,
    "ApprovalStepLevelParentId" uuid,
    "ApprovalGeneralDocumentProcessId" uuid,
    "DocId" uuid,
    "Status" boolean,
    "Step" character varying(250),
    "StepId" uuid
);
 '   DROP TABLE public."ApprovalStepLevel";
       public         heap    postgres    false            �            1259    51009    ConfigColumn    TABLE       CREATE TABLE public."ConfigColumn" (
    "Id" uuid NOT NULL,
    "ViewType" integer NOT NULL,
    "InfoJson" text,
    "CreateDate" timestamp with time zone,
    "CreateUser" character varying(200),
    "UpdateUser" character varying(200),
    "UpdateDate" timestamp with time zone
);
 "   DROP TABLE public."ConfigColumn";
       public         heap    postgres    false            �            1259    51014    ConfigureBrowsingSteps    TABLE     �  CREATE TABLE public."ConfigureBrowsingSteps" (
    "Id" uuid NOT NULL,
    "StepName" character varying(250),
    "ScopeApplication" integer,
    "OfficeId" bigint,
    "ConfigType" integer,
    "Description" character varying(500),
    "CreateDate" timestamp with time zone,
    "CreateUser" character varying(100),
    "UpdateDate" timestamp with time zone,
    "UpdateUser" character varying(100),
    "Active" boolean,
    "IsUnit" boolean,
    "AllOffice" character varying(5)
);
 ,   DROP TABLE public."ConfigureBrowsingSteps";
       public         heap    postgres    false            �            1259    51019    Decentralize    TABLE     L  CREATE TABLE public."Decentralize" (
    "Id" bigint NOT NULL,
    "Parent" bigint,
    "Name" character varying,
    "Description" character varying(250),
    "CreateUser" character varying(250),
    "CreateDate" timestamp without time zone,
    "UpdateUser" character varying(250),
    "UpdateDate" timestamp without time zone
);
 "   DROP TABLE public."Decentralize";
       public         heap    postgres    false            �            1259    51024    DecentralizeDocUser    TABLE     �  CREATE TABLE public."DecentralizeDocUser" (
    "Id" uuid NOT NULL,
    "DecentralizeDocId" uuid,
    "EmployeeId" character varying(250),
    "DecentralizeDocumentLevel" bigint,
    "DecentralizeDocumentNote" character varying(250),
    "CreateUser" character varying(250),
    "CreateDate" timestamp with time zone,
    "UpdateUser" character varying(250),
    "UpdateDate" timestamp with time zone
);
 )   DROP TABLE public."DecentralizeDocUser";
       public         heap    postgres    false            �            1259    51029    DecentralizeDocument    TABLE     T  CREATE TABLE public."DecentralizeDocument" (
    "Id" uuid NOT NULL,
    "Description" character varying(500),
    "DecentralizeDocState" boolean,
    "CreateDate" timestamp with time zone,
    "CreateUser" character varying(250),
    "UpdateDate" timestamp with time zone,
    "UpdateUser" character varying(250),
    "OfficeId" bigint
);
 *   DROP TABLE public."DecentralizeDocument";
       public         heap    postgres    false                       1259    51684    DirectorApprovation    TABLE     �   CREATE TABLE public."DirectorApprovation" (
    "Id" uuid NOT NULL,
    "DocId" uuid,
    "ApprovalUserId" uuid,
    "CreateUser" uuid,
    "CreateDate" timestamp with time zone
);
 )   DROP TABLE public."DirectorApprovation";
       public         heap    postgres    false                       1259    51577    Document    TABLE     '  CREATE TABLE public."Document" (
    "Id" uuid NOT NULL,
    "DocumentCode" character varying(20),
    "GroupDocId" uuid,
    "PatternDocId" uuid,
    "DocName" character varying(250),
    "Priority" integer,
    "ExpirationDate" timestamp with time zone,
    "Description" text,
    "Notes" character varying(500),
    "Explaination" character varying(500),
    "Status" integer,
    "CreateUser" character varying(100),
    "CreateDate" timestamp with time zone,
    "UpdateUser" character varying(100),
    "UpdateDate" timestamp with time zone
);
    DROP TABLE public."Document";
       public         heap    postgres    false            	           1259    51654    DocumentAdvisory    TABLE     l   CREATE TABLE public."DocumentAdvisory" (
    "Id" uuid NOT NULL,
    "DocId" uuid,
    "OfficeId" bigint
);
 &   DROP TABLE public."DocumentAdvisory";
       public         heap    postgres    false                       1259    51741    DocumentComment    TABLE       CREATE TABLE public."DocumentComment" (
    "Id" uuid NOT NULL,
    "OfficeId" bigint,
    "UserId" uuid,
    "MsgComment" text,
    "Type" integer,
    "CreateUser" character varying(100),
    "CreateDate" timestamp with time zone,
    "OfficeName" character varying(200)
);
 %   DROP TABLE public."DocumentComment";
       public         heap    postgres    false            
           1259    51669    DocumentImplementations    TABLE     s   CREATE TABLE public."DocumentImplementations" (
    "Id" uuid NOT NULL,
    "DocId" uuid,
    "OfficeId" bigint
);
 -   DROP TABLE public."DocumentImplementations";
       public         heap    postgres    false                       1259    51724    DocumentReference    TABLE       CREATE TABLE public."DocumentReference" (
    "Id" uuid NOT NULL,
    "DocId" uuid,
    "DocName" character varying(250),
    "DocRefId" uuid,
    "DocRefName" character varying(250),
    "CreateUser" character varying(100),
    "CreateDate" timestamp with time zone
);
 '   DROP TABLE public."DocumentReference";
       public         heap    postgres    false                       1259    51697    FileReference    TABLE     Z  CREATE TABLE public."FileReference" (
    "Id" uuid NOT NULL,
    "Path" character varying(250),
    "Size" bigint,
    "DocId" uuid,
    "FileName" character varying(100),
    "Extension" character varying(250),
    "OriginalFileName" character varying(100),
    "CreateUser" character varying(100),
    "CreateDate" timestamp with time zone
);
 #   DROP TABLE public."FileReference";
       public         heap    postgres    false            �            1259    51034    GroupDocuments    TABLE     �  CREATE TABLE public."GroupDocuments" (
    "GroupDocId" uuid NOT NULL,
    "GroupDocCode" character varying(10),
    "GroupDocName" character varying(500),
    "DocType" integer,
    "AdvisoryUnit" character varying(50),
    "DocNode" character varying(500),
    "DocActive" boolean,
    "CreateUser" character varying(20),
    "CreateDate" timestamp with time zone,
    "UpdateUser" character varying(20),
    "UpdateDate" timestamp with time zone
);
 $   DROP TABLE public."GroupDocuments";
       public         heap    postgres    false            �           0    0 !   COLUMN "GroupDocuments"."DocType"    COMMENT     f   COMMENT ON COLUMN public."GroupDocuments"."DocType" IS '0: Thông báo/phát hành
1: Thực hiện';
          public          postgres    false    237            �           0    0 #   COLUMN "GroupDocuments"."DocActive"    COMMENT     [   COMMENT ON COLUMN public."GroupDocuments"."DocActive" IS 'trạng thái nhóm văn bản';
          public          postgres    false    237            �            1259    51039    ImplementingAgencies    TABLE     �   CREATE TABLE public."ImplementingAgencies" (
    "Id" uuid NOT NULL,
    "ConfigStepId" uuid,
    "ApprovalLevel" bigint,
    "OfficeImplementId" bigint,
    "Description" character varying(500)
);
 *   DROP TABLE public."ImplementingAgencies";
       public         heap    postgres    false            �            1259    51044    Office    TABLE     I  CREATE TABLE public."Office" (
    "Id" bigint NOT NULL,
    "OfficeName" character varying(250),
    "Parent" bigint,
    "Description" character varying(500),
    "CreateUser" character varying(20),
    "CreateDate" timestamp with time zone,
    "UpdateUser" character varying(20),
    "UpdateDate" timestamp with time zone
);
    DROP TABLE public."Office";
       public         heap    postgres    false            �            1259    51049 !   PatternDocDetailByGroupDocGeneral    TABLE     �   CREATE TABLE public."PatternDocDetailByGroupDocGeneral" (
    "Id" uuid NOT NULL,
    "GroupDocumentId" uuid,
    "PatternDocumentId" uuid,
    "ApprovalGeneralDocumentProcessId" uuid
);
 7   DROP TABLE public."PatternDocDetailByGroupDocGeneral";
       public         heap    postgres    false            �            1259    51052    PatternDocOffice    TABLE     �   CREATE TABLE public."PatternDocOffice" (
    "Id" uuid NOT NULL,
    "PatternDocId" uuid,
    "OfficeId" bigint,
    "ParrentId" bigint
);
 &   DROP TABLE public."PatternDocOffice";
       public         heap    postgres    false            �            1259    51055    PatternDocument    TABLE     �  CREATE TABLE public."PatternDocument" (
    "PatternDocId" uuid NOT NULL,
    "PatternDocCode" character varying(10),
    "PatternDocName" character varying(500),
    "GroupDocId" uuid,
    "Description" character varying(500),
    "PatternDocActive" boolean,
    "TemplateDoc" text,
    "CreateUser" character varying(20),
    "CreateDate" timestamp with time zone,
    "UpdateUser" character varying(20),
    "UpdateDate" timestamp with time zone,
    "DocumentValue" character varying(250)
);
 %   DROP TABLE public."PatternDocument";
       public         heap    postgres    false            �            1259    51060 $   PatternDocumentDetailByGroupDocument    TABLE     �   CREATE TABLE public."PatternDocumentDetailByGroupDocument" (
    "Id" uuid NOT NULL,
    "GroupDocumentId" uuid,
    "PatternDocumentId" uuid,
    "ApprovalGeneralDocumentProcessUnitId" uuid
);
 :   DROP TABLE public."PatternDocumentDetailByGroupDocument";
       public         heap    postgres    false            �            1259    51063    Position    TABLE     N  CREATE TABLE public."Position" (
    "Id" bigint NOT NULL,
    "PositionName" character varying(250),
    "Active" boolean,
    "Description" character varying(500),
    "CreateUser" character varying(20),
    "CreateDate" timestamp with time zone,
    "UpdateUser" character varying(20),
    "UpdateDate" timestamp with time zone
);
    DROP TABLE public."Position";
       public         heap    postgres    false            �            1259    51068    Role    TABLE     V  CREATE TABLE public."Role" (
    "Id" uuid NOT NULL,
    "RoleCode" character varying(10),
    "RoleName" character varying(250),
    "Description" character varying(500),
    "CreateUser" character varying(100),
    "CreateDate" timestamp with time zone,
    "UpdateUser" character varying(100),
    "UpdateDate" timestamp with time zone
);
    DROP TABLE public."Role";
       public         heap    postgres    false            �            1259    51073    RoleDecentralize    TABLE     �   CREATE TABLE public."RoleDecentralize" (
    "Id" uuid NOT NULL,
    "DecentralizeId" bigint,
    "RoleId" uuid,
    "ParentId" bigint
);
 &   DROP TABLE public."RoleDecentralize";
       public         heap    postgres    false            �            1259    51076    TextBrowsingSteps    TABLE     �   CREATE TABLE public."TextBrowsingSteps" (
    "Id" uuid NOT NULL,
    stt integer,
    "ConfigureBrowsingStepId" uuid,
    "ApprovalGeneralDocumentProcessId" uuid
);
 '   DROP TABLE public."TextBrowsingSteps";
       public         heap    postgres    false            �            1259    51079    TextBrowsingStepsUnit    TABLE     �   CREATE TABLE public."TextBrowsingStepsUnit" (
    "Id" uuid NOT NULL,
    stt integer,
    "ConfigureBrowsingStepId" uuid,
    "ApprovalGeneralDocumentProcessUnitId" uuid
);
 +   DROP TABLE public."TextBrowsingStepsUnit";
       public         heap    postgres    false            �            1259    51082    UserId_Roles    TABLE     w   CREATE TABLE public."UserId_Roles" (
    "Id" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    "RoleId" uuid NOT NULL
);
 "   DROP TABLE public."UserId_Roles";
       public         heap    postgres    false            �            1259    51085    UserImplement    TABLE     �   CREATE TABLE public."UserImplement" (
    "Id" uuid NOT NULL,
    "EmployeeId" character varying(50),
    "OfficeImplementId" bigint,
    "ConfigureBrowsingStepId" uuid
);
 #   DROP TABLE public."UserImplement";
       public         heap    postgres    false            �            1259    51088 	   UserRoles    TABLE     �  CREATE TABLE public."UserRoles" (
    "UserId" uuid NOT NULL,
    "EmployeeCode" character varying(10),
    "EmployeeName" character varying(250),
    "OfficeId" bigint,
    "PositionId" bigint,
    "Description" character varying(500),
    "CreateDate" timestamp with time zone,
    "CreateUser" character varying(100),
    "UpdateDate" timestamp with time zone,
    "UpdateUser" character varying(100)
);
    DROP TABLE public."UserRoles";
       public         heap    postgres    false            �            1259    51093    ViewAccountDetail    VIEW     "  CREATE VIEW public."ViewAccountDetail" AS
 SELECT a."EmployeeID",
    a."FullName",
    a."Email",
    a."Auto",
    a."Active",
    a."CreateDate",
    a."AvatarUrl",
    a."Level",
    a."Online",
    a."PhoneNumber",
    a."SerialNumber",
    a."SignatureUrl",
    a."UserId",
    a."UserName",
    p."Id" AS positionid,
    p."PositionName",
    o."Id" AS officeid,
    o."OfficeName"
   FROM ((public."Accounts" a
     LEFT JOIN public."Office" o ON ((a."Office" = o."Id")))
     LEFT JOIN public."Position" p ON ((a."Position" = p."Id")));
 &   DROP VIEW public."ViewAccountDetail";
       public          postgres    false    239    229    244    244    229    229    229    229    229    229    229    229    229    229    229    229    229    229    229    239            �            1259    51098 "   ViewApprovalGeneralDocumentProcess    VIEW     j  CREATE VIEW public."ViewApprovalGeneralDocumentProcess" AS
 SELECT au."Id",
    gd."GroupDocId" AS "GroupDocumentId",
    gd."GroupDocName",
    mb."PatternDocName",
    au."Active",
    au."TimeApplication",
    au."Description",
    au."CreateDate",
    au."CreateUser",
    mb."PatternDocId",
    cb."StepName"
   FROM (((public."ApprovalGeneralDocumentProcess" au
     LEFT JOIN public."GroupDocuments" gd ON ((au."GroupDocumentId" = gd."GroupDocId")))
     LEFT JOIN ( SELECT pdb."ApprovalGeneralDocumentProcessId",
            string_agg((pd."PatternDocId")::text, ';'::text) AS "PatternDocId",
            string_agg((pd."PatternDocName")::text, ';'::text) AS "PatternDocName"
           FROM (public."PatternDocDetailByGroupDocGeneral" pdb
             JOIN public."PatternDocument" pd ON ((pdb."PatternDocumentId" = pd."PatternDocId")))
          GROUP BY pdb."ApprovalGeneralDocumentProcessId") mb ON ((au."Id" = mb."ApprovalGeneralDocumentProcessId")))
     LEFT JOIN ( SELECT tu."ApprovalGeneralDocumentProcessId",
            string_agg((cs."StepName")::text, '-->'::text ORDER BY tu.stt) AS "StepName"
           FROM (public."TextBrowsingSteps" tu
             LEFT JOIN public."ConfigureBrowsingSteps" cs ON ((tu."ConfigureBrowsingStepId" = cs."Id")))
          GROUP BY tu."ApprovalGeneralDocumentProcessId") cb ON ((au."Id" = cb."ApprovalGeneralDocumentProcessId")));
 7   DROP VIEW public."ViewApprovalGeneralDocumentProcess";
       public          postgres    false    230    230    230    230    230    230    230    233    233    237    237    240    240    242    242    247    247    247            �            1259    51103 &   ViewApprovalGeneralDocumentProcessUnit    VIEW       CREATE VIEW public."ViewApprovalGeneralDocumentProcessUnit" AS
 SELECT au."Id",
    au."Active",
    au."Description",
    au."TimeApplication",
    au."CreateDate",
    au."CreateUser",
    o."OfficeName",
    o."Id" AS "OfficeId",
    gd."GroupDocName",
    gd."GroupDocId" AS "GroupDocumentId",
    mb."PatternDocName",
    cb."StepName",
    mb."PatternDocId"
   FROM ((((public."ApprovalGeneralDocumentProcessUnit" au
     LEFT JOIN public."Office" o ON ((au."ApplicableUnit" = o."Id")))
     LEFT JOIN public."GroupDocuments" gd ON ((au."GroupDocumentId" = gd."GroupDocId")))
     LEFT JOIN ( SELECT pdb."ApprovalGeneralDocumentProcessUnitId",
            string_agg((pd."PatternDocId")::text, ';'::text) AS "PatternDocId",
            string_agg((pd."PatternDocName")::text, ';'::text) AS "PatternDocName"
           FROM (public."PatternDocumentDetailByGroupDocument" pdb
             LEFT JOIN public."PatternDocument" pd ON ((pdb."PatternDocumentId" = pd."PatternDocId")))
          GROUP BY pdb."ApprovalGeneralDocumentProcessUnitId") mb ON ((au."Id" = mb."ApprovalGeneralDocumentProcessUnitId")))
     LEFT JOIN ( SELECT tu."ApprovalGeneralDocumentProcessUnitId",
            string_agg((cs."StepName")::text, ' > '::text ORDER BY tu.stt) AS "StepName"
           FROM (public."TextBrowsingStepsUnit" tu
             LEFT JOIN public."ConfigureBrowsingSteps" cs ON ((tu."ConfigureBrowsingStepId" = cs."Id")))
          GROUP BY tu."ApprovalGeneralDocumentProcessUnitId") cb ON ((au."Id" = cb."ApprovalGeneralDocumentProcessUnitId")));
 ;   DROP VIEW public."ViewApprovalGeneralDocumentProcessUnit";
       public          postgres    false    248    248    231    231    231    231    231    233    233    237    237    239    239    242    242    243    243    248    231    231    231            �            1259    51108    ViewConfigureBrowsingSteps    VIEW     �  CREATE VIEW public."ViewConfigureBrowsingSteps" AS
 SELECT s."Id" AS "ConfigureBrowsingStepId",
    s."StepName",
    s."ScopeApplication",
    s."ConfigType",
    s."Description",
    s."Active",
    s."CreateDate",
    s."IsUnit",
    s."AllOffice",
    o."Id" AS "OfficeId",
    o."OfficeName",
    si."OfficeImplement"
   FROM ((public."ConfigureBrowsingSteps" s
     LEFT JOIN public."Office" o ON ((s."OfficeId" = o."Id")))
     LEFT JOIN ( SELECT i."ConfigStepId",
            string_agg((oi."OfficeName")::text, ';'::text) AS "OfficeImplement"
           FROM (public."ImplementingAgencies" i
             LEFT JOIN public."Office" oi ON ((i."OfficeImplementId" = oi."Id")))
          GROUP BY i."ConfigStepId") si ON ((s."Id" = si."ConfigStepId")));
 /   DROP VIEW public."ViewConfigureBrowsingSteps";
       public          postgres    false    233    233    233    239    239    238    238    233    233    233    233    233    233    233                        1259    51113    ViewDecentralizeDocument    VIEW       CREATE VIEW public."ViewDecentralizeDocument" AS
 SELECT p."Id",
    f."OfficeName",
    ag."Level",
    p."DecentralizeDocState",
    p."Description",
    p."CreateDate"
   FROM ((public."DecentralizeDocument" p
     LEFT JOIN ( SELECT g."DecentralizeDocId",
            max(g."DecentralizeDocumentLevel") AS "Level"
           FROM public."DecentralizeDocUser" g
          GROUP BY g."DecentralizeDocId") ag ON ((p."Id" = ag."DecentralizeDocId")))
     LEFT JOIN public."Office" f ON ((p."OfficeId" = f."Id")));
 -   DROP VIEW public."ViewDecentralizeDocument";
       public          postgres    false    236    235    235    236    236    236    236    239    239                       1259    51118    ViewGetDetailUserRole    VIEW       CREATE VIEW public."ViewGetDetailUserRole" AS
 SELECT u."UserId",
    u."EmployeeCode",
    u."EmployeeName",
    u."CreateDate",
    u."Description",
    si.roleid,
    si.rolename,
    o."Id" AS officeid,
    o."OfficeName",
    p."Id" AS positionid,
    p."PositionName"
   FROM (((public."UserRoles" u
     LEFT JOIN public."Office" o ON ((u."OfficeId" = o."Id")))
     LEFT JOIN public."Position" p ON ((u."PositionId" = p."Id")))
     LEFT JOIN ( SELECT ur."UserId",
            string_agg(((r."Id")::character(36))::text, ';'::text) AS roleid,
            string_agg((r."RoleName")::text, ';'::text) AS rolename
           FROM (public."UserId_Roles" ur
             LEFT JOIN public."Role" r ON ((ur."RoleId" = r."Id")))
          GROUP BY ur."UserId") si ON ((u."UserId" = si."UserId")));
 *   DROP VIEW public."ViewGetDetailUserRole";
       public          postgres    false    251    251    251    251    251    249    239    239    244    244    245    245    249    251    251                       1259    51123    ViewInfoAccountDetail    VIEW     b  CREATE VIEW public."ViewInfoAccountDetail" AS
 SELECT a."UserName",
    a."EmployeeID",
    a."FullName",
    o."Id" AS officeid,
    o."OfficeName",
    p."Id" AS positionid,
    p."PositionName"
   FROM ((public."Accounts" a
     LEFT JOIN public."Office" o ON ((a."Office" = o."Id")))
     LEFT JOIN public."Position" p ON ((a."Position" = p."Id")));
 *   DROP VIEW public."ViewInfoAccountDetail";
       public          postgres    false    244    229    229    229    229    229    239    239    244                       1259    51128    ViewSampleDocument    VIEW     �  CREATE VIEW public."ViewSampleDocument" AS
 SELECT p."PatternDocId",
    p."PatternDocCode",
    p."PatternDocName",
    p."Description",
    p."PatternDocActive",
    p."TemplateDoc",
    p."CreateDate",
    g."GroupDocId",
    g."GroupDocName",
    g."DocType",
    pdo.officename
   FROM ((public."PatternDocument" p
     LEFT JOIN public."GroupDocuments" g ON ((p."GroupDocId" = g."GroupDocId")))
     LEFT JOIN ( SELECT pd."PatternDocId",
            string_agg((o."OfficeName")::text, ';'::text) AS officename
           FROM (public."PatternDocOffice" pd
             LEFT JOIN public."Office" o ON ((pd."OfficeId" = o."Id")))
          GROUP BY pd."PatternDocId") pdo ON ((p."PatternDocId" = pdo."PatternDocId")));
 '   DROP VIEW public."ViewSampleDocument";
       public          postgres    false    239    242    242    242    242    237    237    242    242    242    237    241    241    239    242                       1259    51133    __EFMigrationsHistory    TABLE     �   CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);
 +   DROP TABLE public."__EFMigrationsHistory";
       public         heap    postgres    false            8           2604    51136 
   counter id    DEFAULT     l   ALTER TABLE ONLY hangfire.counter ALTER COLUMN id SET DEFAULT nextval('hangfire.counter_id_seq'::regclass);
 ;   ALTER TABLE hangfire.counter ALTER COLUMN id DROP DEFAULT;
       hangfire          postgres    false    211    210            :           2604    51137    hash id    DEFAULT     f   ALTER TABLE ONLY hangfire.hash ALTER COLUMN id SET DEFAULT nextval('hangfire.hash_id_seq'::regclass);
 8   ALTER TABLE hangfire.hash ALTER COLUMN id DROP DEFAULT;
       hangfire          postgres    false    213    212            <           2604    51138    job id    DEFAULT     d   ALTER TABLE ONLY hangfire.job ALTER COLUMN id SET DEFAULT nextval('hangfire.job_id_seq'::regclass);
 7   ALTER TABLE hangfire.job ALTER COLUMN id DROP DEFAULT;
       hangfire          postgres    false    215    214            >           2604    51139    jobparameter id    DEFAULT     v   ALTER TABLE ONLY hangfire.jobparameter ALTER COLUMN id SET DEFAULT nextval('hangfire.jobparameter_id_seq'::regclass);
 @   ALTER TABLE hangfire.jobparameter ALTER COLUMN id DROP DEFAULT;
       hangfire          postgres    false    217    216            @           2604    51140    jobqueue id    DEFAULT     n   ALTER TABLE ONLY hangfire.jobqueue ALTER COLUMN id SET DEFAULT nextval('hangfire.jobqueue_id_seq'::regclass);
 <   ALTER TABLE hangfire.jobqueue ALTER COLUMN id DROP DEFAULT;
       hangfire          postgres    false    219    218            B           2604    51141    list id    DEFAULT     f   ALTER TABLE ONLY hangfire.list ALTER COLUMN id SET DEFAULT nextval('hangfire.list_id_seq'::regclass);
 8   ALTER TABLE hangfire.list ALTER COLUMN id DROP DEFAULT;
       hangfire          postgres    false    221    220            F           2604    51142    set id    DEFAULT     d   ALTER TABLE ONLY hangfire.set ALTER COLUMN id SET DEFAULT nextval('hangfire.set_id_seq'::regclass);
 7   ALTER TABLE hangfire.set ALTER COLUMN id DROP DEFAULT;
       hangfire          postgres    false    226    225            H           2604    51143    state id    DEFAULT     h   ALTER TABLE ONLY hangfire.state ALTER COLUMN id SET DEFAULT nextval('hangfire.state_id_seq'::regclass);
 9   ALTER TABLE hangfire.state ALTER COLUMN id DROP DEFAULT;
       hangfire          postgres    false    228    227            P          0    50924    counter 
   TABLE DATA           =   COPY hangfire.counter (id, key, value, expireat) FROM stdin;
    hangfire          postgres    false    210   �&      R          0    50930    hash 
   TABLE DATA           N   COPY hangfire.hash (id, key, field, value, expireat, updatecount) FROM stdin;
    hangfire          postgres    false    212   �0      T          0    50937    job 
   TABLE DATA           t   COPY hangfire.job (id, stateid, statename, invocationdata, arguments, createdat, expireat, updatecount) FROM stdin;
    hangfire          postgres    false    214   �2      V          0    50944    jobparameter 
   TABLE DATA           M   COPY hangfire.jobparameter (id, jobid, name, value, updatecount) FROM stdin;
    hangfire          postgres    false    216   :      X          0    50951    jobqueue 
   TABLE DATA           N   COPY hangfire.jobqueue (id, jobid, queue, fetchedat, updatecount) FROM stdin;
    hangfire          postgres    false    218   `@      Z          0    50958    list 
   TABLE DATA           G   COPY hangfire.list (id, key, value, expireat, updatecount) FROM stdin;
    hangfire          postgres    false    220   }@      \          0    50965    lock 
   TABLE DATA           A   COPY hangfire.lock (resource, updatecount, acquired) FROM stdin;
    hangfire          postgres    false    222   �@      ]          0    50971    schema 
   TABLE DATA           +   COPY hangfire.schema (version) FROM stdin;
    hangfire          postgres    false    223   �@      ^          0    50974    server 
   TABLE DATA           H   COPY hangfire.server (id, data, lastheartbeat, updatecount) FROM stdin;
    hangfire          postgres    false    224   �@      _          0    50980    set 
   TABLE DATA           M   COPY hangfire.set (id, key, score, value, expireat, updatecount) FROM stdin;
    hangfire          postgres    false    225   |A      a          0    50987    state 
   TABLE DATA           X   COPY hangfire.state (id, jobid, name, reason, createdat, data, updatecount) FROM stdin;
    hangfire          postgres    false    227   �A      c          0    50994    Accounts 
   TABLE DATA           7  COPY public."Accounts" ("UserId", "UserName", "PasswordHash", "EmployeeID", "Office", "Unit", "Position", "FullName", "Email", "SignatureUrl", "PhoneNumber", "Auto", "TimeLogin", "Online", "Level", "HC", "Active", "AvatarUrl", "SerialNumber", "CreateUser", "CreateDate", "UpdateUser", "UpdateDate") FROM stdin;
    public          postgres    false    229   ��      �          0    51709    AdvisoryStaff 
   TABLE DATA           �   COPY public."AdvisoryStaff" ("Id", "DocId", "AdvisoryUserId", "AdvisoryUserName", "PositionName", "Status", "PositionId") FROM stdin;
    public          postgres    false    269   X�      d          0    50999    ApprovalGeneralDocumentProcess 
   TABLE DATA           �   COPY public."ApprovalGeneralDocumentProcess" ("Id", "GroupDocumentId", "TimeApplication", "Description", "Active", "CreateDate", "CreateUser", "UpdateDate", "UpdateUser") FROM stdin;
    public          postgres    false    230   u�      e          0    51004 "   ApprovalGeneralDocumentProcessUnit 
   TABLE DATA           �   COPY public."ApprovalGeneralDocumentProcessUnit" ("Id", "ApplicableUnit", "GroupDocumentId", "TimeApplication", "Description", "Active", "CreateDate", "CreateUser", "UpdateDate", "UpdateUser") FROM stdin;
    public          postgres    false    231   ܔ      }          0    51614    ApprovalOfficeLevel 
   TABLE DATA           y   COPY public."ApprovalOfficeLevel" ("Id", "ApprovalStepLevelId", "OfficeId", "OfficeName", "Status", "Level") FROM stdin;
    public          postgres    false    263   @�      ~          0    51629    ApprovalStaffLevel 
   TABLE DATA           �   COPY public."ApprovalStaffLevel" ("Id", "ApprovalOfficeLevelId", "ApprovalUserId", "ApprovalUserName", "PositionName", "Level", "IsApproved") FROM stdin;
    public          postgres    false    264   ]�      |          0    51594    ApprovalStepLevel 
   TABLE DATA           �   COPY public."ApprovalStepLevel" ("Id", "ApprovalStepLevelParentId", "ApprovalGeneralDocumentProcessId", "DocId", "Status", "Step", "StepId") FROM stdin;
    public          postgres    false    262   z�      f          0    51009    ConfigColumn 
   TABLE DATA           ~   COPY public."ConfigColumn" ("Id", "ViewType", "InfoJson", "CreateDate", "CreateUser", "UpdateUser", "UpdateDate") FROM stdin;
    public          postgres    false    232   ��      g          0    51014    ConfigureBrowsingSteps 
   TABLE DATA           �   COPY public."ConfigureBrowsingSteps" ("Id", "StepName", "ScopeApplication", "OfficeId", "ConfigType", "Description", "CreateDate", "CreateUser", "UpdateDate", "UpdateUser", "Active", "IsUnit", "AllOffice") FROM stdin;
    public          postgres    false    233   w�      h          0    51019    Decentralize 
   TABLE DATA           �   COPY public."Decentralize" ("Id", "Parent", "Name", "Description", "CreateUser", "CreateDate", "UpdateUser", "UpdateDate") FROM stdin;
    public          postgres    false    234   
�      i          0    51024    DecentralizeDocUser 
   TABLE DATA           �   COPY public."DecentralizeDocUser" ("Id", "DecentralizeDocId", "EmployeeId", "DecentralizeDocumentLevel", "DecentralizeDocumentNote", "CreateUser", "CreateDate", "UpdateUser", "UpdateDate") FROM stdin;
    public          postgres    false    235   /�      j          0    51029    DecentralizeDocument 
   TABLE DATA           �   COPY public."DecentralizeDocument" ("Id", "Description", "DecentralizeDocState", "CreateDate", "CreateUser", "UpdateDate", "UpdateUser", "OfficeId") FROM stdin;
    public          postgres    false    236   ��      �          0    51684    DirectorApprovation 
   TABLE DATA           l   COPY public."DirectorApprovation" ("Id", "DocId", "ApprovalUserId", "CreateUser", "CreateDate") FROM stdin;
    public          postgres    false    267   ��      {          0    51577    Document 
   TABLE DATA           �   COPY public."Document" ("Id", "DocumentCode", "GroupDocId", "PatternDocId", "DocName", "Priority", "ExpirationDate", "Description", "Notes", "Explaination", "Status", "CreateUser", "CreateDate", "UpdateUser", "UpdateDate") FROM stdin;
    public          postgres    false    261   ã                0    51654    DocumentAdvisory 
   TABLE DATA           G   COPY public."DocumentAdvisory" ("Id", "DocId", "OfficeId") FROM stdin;
    public          postgres    false    265   �      �          0    51741    DocumentComment 
   TABLE DATA           �   COPY public."DocumentComment" ("Id", "OfficeId", "UserId", "MsgComment", "Type", "CreateUser", "CreateDate", "OfficeName") FROM stdin;
    public          postgres    false    271   ��      �          0    51669    DocumentImplementations 
   TABLE DATA           N   COPY public."DocumentImplementations" ("Id", "DocId", "OfficeId") FROM stdin;
    public          postgres    false    266   �      �          0    51724    DocumentReference 
   TABLE DATA           }   COPY public."DocumentReference" ("Id", "DocId", "DocName", "DocRefId", "DocRefName", "CreateUser", "CreateDate") FROM stdin;
    public          postgres    false    270   7�      �          0    51697    FileReference 
   TABLE DATA           �   COPY public."FileReference" ("Id", "Path", "Size", "DocId", "FileName", "Extension", "OriginalFileName", "CreateUser", "CreateDate") FROM stdin;
    public          postgres    false    268   T�      k          0    51034    GroupDocuments 
   TABLE DATA           �   COPY public."GroupDocuments" ("GroupDocId", "GroupDocCode", "GroupDocName", "DocType", "AdvisoryUnit", "DocNode", "DocActive", "CreateUser", "CreateDate", "UpdateUser", "UpdateDate") FROM stdin;
    public          postgres    false    237   q�      l          0    51039    ImplementingAgencies 
   TABLE DATA           {   COPY public."ImplementingAgencies" ("Id", "ConfigStepId", "ApprovalLevel", "OfficeImplementId", "Description") FROM stdin;
    public          postgres    false    238   �      m          0    51044    Office 
   TABLE DATA           �   COPY public."Office" ("Id", "OfficeName", "Parent", "Description", "CreateUser", "CreateDate", "UpdateUser", "UpdateDate") FROM stdin;
    public          postgres    false    239   p�      n          0    51049 !   PatternDocDetailByGroupDocGeneral 
   TABLE DATA           �   COPY public."PatternDocDetailByGroupDocGeneral" ("Id", "GroupDocumentId", "PatternDocumentId", "ApprovalGeneralDocumentProcessId") FROM stdin;
    public          postgres    false    240    �      o          0    51052    PatternDocOffice 
   TABLE DATA           [   COPY public."PatternDocOffice" ("Id", "PatternDocId", "OfficeId", "ParrentId") FROM stdin;
    public          postgres    false    241   ;�      p          0    51055    PatternDocument 
   TABLE DATA           �   COPY public."PatternDocument" ("PatternDocId", "PatternDocCode", "PatternDocName", "GroupDocId", "Description", "PatternDocActive", "TemplateDoc", "CreateUser", "CreateDate", "UpdateUser", "UpdateDate", "DocumentValue") FROM stdin;
    public          postgres    false    242   /�      q          0    51060 $   PatternDocumentDetailByGroupDocument 
   TABLE DATA           �   COPY public."PatternDocumentDetailByGroupDocument" ("Id", "GroupDocumentId", "PatternDocumentId", "ApprovalGeneralDocumentProcessUnitId") FROM stdin;
    public          postgres    false    243   }�      r          0    51063    Position 
   TABLE DATA           �   COPY public."Position" ("Id", "PositionName", "Active", "Description", "CreateUser", "CreateDate", "UpdateUser", "UpdateDate") FROM stdin;
    public          postgres    false    244   ��      s          0    51068    Role 
   TABLE DATA           �   COPY public."Role" ("Id", "RoleCode", "RoleName", "Description", "CreateUser", "CreateDate", "UpdateUser", "UpdateDate") FROM stdin;
    public          postgres    false    245   �      t          0    51073    RoleDecentralize 
   TABLE DATA           Z   COPY public."RoleDecentralize" ("Id", "DecentralizeId", "RoleId", "ParentId") FROM stdin;
    public          postgres    false    246   �      u          0    51076    TextBrowsingSteps 
   TABLE DATA           w   COPY public."TextBrowsingSteps" ("Id", stt, "ConfigureBrowsingStepId", "ApprovalGeneralDocumentProcessId") FROM stdin;
    public          postgres    false    247    �      v          0    51079    TextBrowsingStepsUnit 
   TABLE DATA              COPY public."TextBrowsingStepsUnit" ("Id", stt, "ConfigureBrowsingStepId", "ApprovalGeneralDocumentProcessUnitId") FROM stdin;
    public          postgres    false    248   ��      w          0    51082    UserId_Roles 
   TABLE DATA           B   COPY public."UserId_Roles" ("Id", "UserId", "RoleId") FROM stdin;
    public          postgres    false    249   �      x          0    51085    UserImplement 
   TABLE DATA           m   COPY public."UserImplement" ("Id", "EmployeeId", "OfficeImplementId", "ConfigureBrowsingStepId") FROM stdin;
    public          postgres    false    250   ��      y          0    51088 	   UserRoles 
   TABLE DATA           �   COPY public."UserRoles" ("UserId", "EmployeeCode", "EmployeeName", "OfficeId", "PositionId", "Description", "CreateDate", "CreateUser", "UpdateDate", "UpdateUser") FROM stdin;
    public          postgres    false    251   ��      z          0    51133    __EFMigrationsHistory 
   TABLE DATA           R   COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
    public          postgres    false    260   C�      �           0    0    counter_id_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('hangfire.counter_id_seq', 812, true);
          hangfire          postgres    false    211            �           0    0    hash_id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('hangfire.hash_id_seq', 108, true);
          hangfire          postgres    false    213            �           0    0 
   job_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('hangfire.job_id_seq', 244, true);
          hangfire          postgres    false    215            �           0    0    jobparameter_id_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('hangfire.jobparameter_id_seq', 1016, true);
          hangfire          postgres    false    217            �           0    0    jobqueue_id_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('hangfire.jobqueue_id_seq', 373, true);
          hangfire          postgres    false    219            �           0    0    list_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('hangfire.list_id_seq', 1, false);
          hangfire          postgres    false    221            �           0    0 
   set_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('hangfire.set_id_seq', 588, true);
          hangfire          postgres    false    226            �           0    0    state_id_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('hangfire.state_id_seq', 1359, true);
          hangfire          postgres    false    228            J           2606    51145    counter counter_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY hangfire.counter
    ADD CONSTRAINT counter_pkey PRIMARY KEY (id);
 @   ALTER TABLE ONLY hangfire.counter DROP CONSTRAINT counter_pkey;
       hangfire            postgres    false    210            N           2606    51147    hash hash_key_field_key 
   CONSTRAINT     Z   ALTER TABLE ONLY hangfire.hash
    ADD CONSTRAINT hash_key_field_key UNIQUE (key, field);
 C   ALTER TABLE ONLY hangfire.hash DROP CONSTRAINT hash_key_field_key;
       hangfire            postgres    false    212    212            P           2606    51149    hash hash_pkey 
   CONSTRAINT     N   ALTER TABLE ONLY hangfire.hash
    ADD CONSTRAINT hash_pkey PRIMARY KEY (id);
 :   ALTER TABLE ONLY hangfire.hash DROP CONSTRAINT hash_pkey;
       hangfire            postgres    false    212            U           2606    51151    job job_pkey 
   CONSTRAINT     L   ALTER TABLE ONLY hangfire.job
    ADD CONSTRAINT job_pkey PRIMARY KEY (id);
 8   ALTER TABLE ONLY hangfire.job DROP CONSTRAINT job_pkey;
       hangfire            postgres    false    214            X           2606    51153    jobparameter jobparameter_pkey 
   CONSTRAINT     ^   ALTER TABLE ONLY hangfire.jobparameter
    ADD CONSTRAINT jobparameter_pkey PRIMARY KEY (id);
 J   ALTER TABLE ONLY hangfire.jobparameter DROP CONSTRAINT jobparameter_pkey;
       hangfire            postgres    false    216            \           2606    51155    jobqueue jobqueue_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY hangfire.jobqueue
    ADD CONSTRAINT jobqueue_pkey PRIMARY KEY (id);
 B   ALTER TABLE ONLY hangfire.jobqueue DROP CONSTRAINT jobqueue_pkey;
       hangfire            postgres    false    218            `           2606    51157    list list_pkey 
   CONSTRAINT     N   ALTER TABLE ONLY hangfire.list
    ADD CONSTRAINT list_pkey PRIMARY KEY (id);
 :   ALTER TABLE ONLY hangfire.list DROP CONSTRAINT list_pkey;
       hangfire            postgres    false    220            b           2606    51159    lock lock_resource_key 
   CONSTRAINT     W   ALTER TABLE ONLY hangfire.lock
    ADD CONSTRAINT lock_resource_key UNIQUE (resource);
 B   ALTER TABLE ONLY hangfire.lock DROP CONSTRAINT lock_resource_key;
       hangfire            postgres    false    222            d           2606    51161    schema schema_pkey 
   CONSTRAINT     W   ALTER TABLE ONLY hangfire.schema
    ADD CONSTRAINT schema_pkey PRIMARY KEY (version);
 >   ALTER TABLE ONLY hangfire.schema DROP CONSTRAINT schema_pkey;
       hangfire            postgres    false    223            f           2606    51163    server server_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY hangfire.server
    ADD CONSTRAINT server_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY hangfire.server DROP CONSTRAINT server_pkey;
       hangfire            postgres    false    224            j           2606    51165    set set_key_value_key 
   CONSTRAINT     X   ALTER TABLE ONLY hangfire.set
    ADD CONSTRAINT set_key_value_key UNIQUE (key, value);
 A   ALTER TABLE ONLY hangfire.set DROP CONSTRAINT set_key_value_key;
       hangfire            postgres    false    225    225            l           2606    51167    set set_pkey 
   CONSTRAINT     L   ALTER TABLE ONLY hangfire.set
    ADD CONSTRAINT set_pkey PRIMARY KEY (id);
 8   ALTER TABLE ONLY hangfire.set DROP CONSTRAINT set_pkey;
       hangfire            postgres    false    225            o           2606    51169    state state_pkey 
   CONSTRAINT     P   ALTER TABLE ONLY hangfire.state
    ADD CONSTRAINT state_pkey PRIMARY KEY (id);
 <   ALTER TABLE ONLY hangfire.state DROP CONSTRAINT state_pkey;
       hangfire            postgres    false    227            q           2606    51171    Accounts Accounts_pkey 
   CONSTRAINT     ^   ALTER TABLE ONLY public."Accounts"
    ADD CONSTRAINT "Accounts_pkey" PRIMARY KEY ("UserId");
 D   ALTER TABLE ONLY public."Accounts" DROP CONSTRAINT "Accounts_pkey";
       public            postgres    false    229            �           2606    51713     AdvisoryStaff AdvisoryStaff_pkey 
   CONSTRAINT     d   ALTER TABLE ONLY public."AdvisoryStaff"
    ADD CONSTRAINT "AdvisoryStaff_pkey" PRIMARY KEY ("Id");
 N   ALTER TABLE ONLY public."AdvisoryStaff" DROP CONSTRAINT "AdvisoryStaff_pkey";
       public            postgres    false    269            s           2606    51173 B   ApprovalGeneralDocumentProcess ApprovalGeneralDocumentProcess_pkey 
   CONSTRAINT     �   ALTER TABLE ONLY public."ApprovalGeneralDocumentProcess"
    ADD CONSTRAINT "ApprovalGeneralDocumentProcess_pkey" PRIMARY KEY ("Id");
 p   ALTER TABLE ONLY public."ApprovalGeneralDocumentProcess" DROP CONSTRAINT "ApprovalGeneralDocumentProcess_pkey";
       public            postgres    false    230            �           2606    51618 ,   ApprovalOfficeLevel ApprovalOfficeLevel_pkey 
   CONSTRAINT     p   ALTER TABLE ONLY public."ApprovalOfficeLevel"
    ADD CONSTRAINT "ApprovalOfficeLevel_pkey" PRIMARY KEY ("Id");
 Z   ALTER TABLE ONLY public."ApprovalOfficeLevel" DROP CONSTRAINT "ApprovalOfficeLevel_pkey";
       public            postgres    false    263            �           2606    51633 *   ApprovalStaffLevel ApprovalStaffLevel_pkey 
   CONSTRAINT     n   ALTER TABLE ONLY public."ApprovalStaffLevel"
    ADD CONSTRAINT "ApprovalStaffLevel_pkey" PRIMARY KEY ("Id");
 X   ALTER TABLE ONLY public."ApprovalStaffLevel" DROP CONSTRAINT "ApprovalStaffLevel_pkey";
       public            postgres    false    264            �           2606    51598 (   ApprovalStepLevel ApprovalStepLevel_pkey 
   CONSTRAINT     l   ALTER TABLE ONLY public."ApprovalStepLevel"
    ADD CONSTRAINT "ApprovalStepLevel_pkey" PRIMARY KEY ("Id");
 V   ALTER TABLE ONLY public."ApprovalStepLevel" DROP CONSTRAINT "ApprovalStepLevel_pkey";
       public            postgres    false    262            w           2606    51175    ConfigColumn ConfigColumn_pkey 
   CONSTRAINT     b   ALTER TABLE ONLY public."ConfigColumn"
    ADD CONSTRAINT "ConfigColumn_pkey" PRIMARY KEY ("Id");
 L   ALTER TABLE ONLY public."ConfigColumn" DROP CONSTRAINT "ConfigColumn_pkey";
       public            postgres    false    232            u           2606    51177 B   ApprovalGeneralDocumentProcessUnit ConfigureBrowsingStepsUnit_pkey 
   CONSTRAINT     �   ALTER TABLE ONLY public."ApprovalGeneralDocumentProcessUnit"
    ADD CONSTRAINT "ConfigureBrowsingStepsUnit_pkey" PRIMARY KEY ("Id");
 p   ALTER TABLE ONLY public."ApprovalGeneralDocumentProcessUnit" DROP CONSTRAINT "ConfigureBrowsingStepsUnit_pkey";
       public            postgres    false    231            y           2606    51179 2   ConfigureBrowsingSteps ConfigureBrowsingSteps_pkey 
   CONSTRAINT     v   ALTER TABLE ONLY public."ConfigureBrowsingSteps"
    ADD CONSTRAINT "ConfigureBrowsingSteps_pkey" PRIMARY KEY ("Id");
 `   ALTER TABLE ONLY public."ConfigureBrowsingSteps" DROP CONSTRAINT "ConfigureBrowsingSteps_pkey";
       public            postgres    false    233            }           2606    51181 .   DecentralizeDocUser DecentralizeDocOffice_pkey 
   CONSTRAINT     r   ALTER TABLE ONLY public."DecentralizeDocUser"
    ADD CONSTRAINT "DecentralizeDocOffice_pkey" PRIMARY KEY ("Id");
 \   ALTER TABLE ONLY public."DecentralizeDocUser" DROP CONSTRAINT "DecentralizeDocOffice_pkey";
       public            postgres    false    235                       2606    51183 .   DecentralizeDocument DecentralizeDocument_pkey 
   CONSTRAINT     r   ALTER TABLE ONLY public."DecentralizeDocument"
    ADD CONSTRAINT "DecentralizeDocument_pkey" PRIMARY KEY ("Id");
 \   ALTER TABLE ONLY public."DecentralizeDocument" DROP CONSTRAINT "DecentralizeDocument_pkey";
       public            postgres    false    236            {           2606    51185    Decentralize Decentralize_PK 
   CONSTRAINT     `   ALTER TABLE ONLY public."Decentralize"
    ADD CONSTRAINT "Decentralize_PK" PRIMARY KEY ("Id");
 J   ALTER TABLE ONLY public."Decentralize" DROP CONSTRAINT "Decentralize_PK";
       public            postgres    false    234            �           2606    51762 ,   DirectorApprovation DirectorApprovation_pkey 
   CONSTRAINT     p   ALTER TABLE ONLY public."DirectorApprovation"
    ADD CONSTRAINT "DirectorApprovation_pkey" PRIMARY KEY ("Id");
 Z   ALTER TABLE ONLY public."DirectorApprovation" DROP CONSTRAINT "DirectorApprovation_pkey";
       public            postgres    false    267            �           2606    51658 &   DocumentAdvisory DocumentAdvisory_pkey 
   CONSTRAINT     j   ALTER TABLE ONLY public."DocumentAdvisory"
    ADD CONSTRAINT "DocumentAdvisory_pkey" PRIMARY KEY ("Id");
 T   ALTER TABLE ONLY public."DocumentAdvisory" DROP CONSTRAINT "DocumentAdvisory_pkey";
       public            postgres    false    265            �           2606    51764 $   DocumentComment DocumentComment_pkey 
   CONSTRAINT     h   ALTER TABLE ONLY public."DocumentComment"
    ADD CONSTRAINT "DocumentComment_pkey" PRIMARY KEY ("Id");
 R   ALTER TABLE ONLY public."DocumentComment" DROP CONSTRAINT "DocumentComment_pkey";
       public            postgres    false    271            �           2606    51673 4   DocumentImplementations DocumentImplementations_pkey 
   CONSTRAINT     x   ALTER TABLE ONLY public."DocumentImplementations"
    ADD CONSTRAINT "DocumentImplementations_pkey" PRIMARY KEY ("Id");
 b   ALTER TABLE ONLY public."DocumentImplementations" DROP CONSTRAINT "DocumentImplementations_pkey";
       public            postgres    false    266            �           2606    51730 (   DocumentReference DocumentReference_pkey 
   CONSTRAINT     l   ALTER TABLE ONLY public."DocumentReference"
    ADD CONSTRAINT "DocumentReference_pkey" PRIMARY KEY ("Id");
 V   ALTER TABLE ONLY public."DocumentReference" DROP CONSTRAINT "DocumentReference_pkey";
       public            postgres    false    270            �           2606    51583    Document Document_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public."Document"
    ADD CONSTRAINT "Document_pkey" PRIMARY KEY ("Id");
 D   ALTER TABLE ONLY public."Document" DROP CONSTRAINT "Document_pkey";
       public            postgres    false    261            �           2606    51703     FileReference FileReference_pkey 
   CONSTRAINT     d   ALTER TABLE ONLY public."FileReference"
    ADD CONSTRAINT "FileReference_pkey" PRIMARY KEY ("Id");
 N   ALTER TABLE ONLY public."FileReference" DROP CONSTRAINT "FileReference_pkey";
       public            postgres    false    268            �           2606    51187    GroupDocuments GroupDocId_pkey 
   CONSTRAINT     j   ALTER TABLE ONLY public."GroupDocuments"
    ADD CONSTRAINT "GroupDocId_pkey" PRIMARY KEY ("GroupDocId");
 L   ALTER TABLE ONLY public."GroupDocuments" DROP CONSTRAINT "GroupDocId_pkey";
       public            postgres    false    237            �           2606    51189 .   ImplementingAgencies ImplementingAgencies_pkey 
   CONSTRAINT     r   ALTER TABLE ONLY public."ImplementingAgencies"
    ADD CONSTRAINT "ImplementingAgencies_pkey" PRIMARY KEY ("Id");
 \   ALTER TABLE ONLY public."ImplementingAgencies" DROP CONSTRAINT "ImplementingAgencies_pkey";
       public            postgres    false    238            �           2606    51191    Office Office_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public."Office"
    ADD CONSTRAINT "Office_pkey" PRIMARY KEY ("Id");
 @   ALTER TABLE ONLY public."Office" DROP CONSTRAINT "Office_pkey";
       public            postgres    false    239            �           2606    51193 .   __EFMigrationsHistory PK___EFMigrationsHistory 
   CONSTRAINT     {   ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");
 \   ALTER TABLE ONLY public."__EFMigrationsHistory" DROP CONSTRAINT "PK___EFMigrationsHistory";
       public            postgres    false    260            �           2606    51195 &   PatternDocOffice PatternDocOffice_pkey 
   CONSTRAINT     j   ALTER TABLE ONLY public."PatternDocOffice"
    ADD CONSTRAINT "PatternDocOffice_pkey" PRIMARY KEY ("Id");
 T   ALTER TABLE ONLY public."PatternDocOffice" DROP CONSTRAINT "PatternDocOffice_pkey";
       public            postgres    false    241            �           2606    51197 R   PatternDocDetailByGroupDocGeneral PatternDocumentDetailByGroupDocumentGeneral_pkey 
   CONSTRAINT     �   ALTER TABLE ONLY public."PatternDocDetailByGroupDocGeneral"
    ADD CONSTRAINT "PatternDocumentDetailByGroupDocumentGeneral_pkey" PRIMARY KEY ("Id");
 �   ALTER TABLE ONLY public."PatternDocDetailByGroupDocGeneral" DROP CONSTRAINT "PatternDocumentDetailByGroupDocumentGeneral_pkey";
       public            postgres    false    240            �           2606    51199 N   PatternDocumentDetailByGroupDocument PatternDocumentDetailByGroupDocument_pkey 
   CONSTRAINT     �   ALTER TABLE ONLY public."PatternDocumentDetailByGroupDocument"
    ADD CONSTRAINT "PatternDocumentDetailByGroupDocument_pkey" PRIMARY KEY ("Id");
 |   ALTER TABLE ONLY public."PatternDocumentDetailByGroupDocument" DROP CONSTRAINT "PatternDocumentDetailByGroupDocument_pkey";
       public            postgres    false    243            �           2606    51201 $   PatternDocument PatternDocument_pkey 
   CONSTRAINT     r   ALTER TABLE ONLY public."PatternDocument"
    ADD CONSTRAINT "PatternDocument_pkey" PRIMARY KEY ("PatternDocId");
 R   ALTER TABLE ONLY public."PatternDocument" DROP CONSTRAINT "PatternDocument_pkey";
       public            postgres    false    242            �           2606    51203    Position Position_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public."Position"
    ADD CONSTRAINT "Position_pkey" PRIMARY KEY ("Id");
 D   ALTER TABLE ONLY public."Position" DROP CONSTRAINT "Position_pkey";
       public            postgres    false    244            �           2606    51205 &   RoleDecentralize RoleDecentralize_pkey 
   CONSTRAINT     j   ALTER TABLE ONLY public."RoleDecentralize"
    ADD CONSTRAINT "RoleDecentralize_pkey" PRIMARY KEY ("Id");
 T   ALTER TABLE ONLY public."RoleDecentralize" DROP CONSTRAINT "RoleDecentralize_pkey";
       public            postgres    false    246            �           2606    51207    Role Role_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public."Role"
    ADD CONSTRAINT "Role_pkey" PRIMARY KEY ("Id");
 <   ALTER TABLE ONLY public."Role" DROP CONSTRAINT "Role_pkey";
       public            postgres    false    245            �           2606    51209 0   TextBrowsingStepsUnit TextBrowsingStepsUnit_pkey 
   CONSTRAINT     t   ALTER TABLE ONLY public."TextBrowsingStepsUnit"
    ADD CONSTRAINT "TextBrowsingStepsUnit_pkey" PRIMARY KEY ("Id");
 ^   ALTER TABLE ONLY public."TextBrowsingStepsUnit" DROP CONSTRAINT "TextBrowsingStepsUnit_pkey";
       public            postgres    false    248            �           2606    51211 (   TextBrowsingSteps TextBrowsingSteps_pkey 
   CONSTRAINT     l   ALTER TABLE ONLY public."TextBrowsingSteps"
    ADD CONSTRAINT "TextBrowsingSteps_pkey" PRIMARY KEY ("Id");
 V   ALTER TABLE ONLY public."TextBrowsingSteps" DROP CONSTRAINT "TextBrowsingSteps_pkey";
       public            postgres    false    247            �           2606    51213     UserImplement UserImplement_pkey 
   CONSTRAINT     d   ALTER TABLE ONLY public."UserImplement"
    ADD CONSTRAINT "UserImplement_pkey" PRIMARY KEY ("Id");
 N   ALTER TABLE ONLY public."UserImplement" DROP CONSTRAINT "UserImplement_pkey";
       public            postgres    false    250            �           2606    51215     UserId_Roles UserRole_Roles_pkey 
   CONSTRAINT     d   ALTER TABLE ONLY public."UserId_Roles"
    ADD CONSTRAINT "UserRole_Roles_pkey" PRIMARY KEY ("Id");
 N   ALTER TABLE ONLY public."UserId_Roles" DROP CONSTRAINT "UserRole_Roles_pkey";
       public            postgres    false    249            �           2606    51217    UserRoles UserRoles_pkey 
   CONSTRAINT     `   ALTER TABLE ONLY public."UserRoles"
    ADD CONSTRAINT "UserRoles_pkey" PRIMARY KEY ("UserId");
 F   ALTER TABLE ONLY public."UserRoles" DROP CONSTRAINT "UserRoles_pkey";
       public            postgres    false    251            K           1259    51218    ix_hangfire_counter_expireat    INDEX     V   CREATE INDEX ix_hangfire_counter_expireat ON hangfire.counter USING btree (expireat);
 2   DROP INDEX hangfire.ix_hangfire_counter_expireat;
       hangfire            postgres    false    210            L           1259    51219    ix_hangfire_counter_key    INDEX     L   CREATE INDEX ix_hangfire_counter_key ON hangfire.counter USING btree (key);
 -   DROP INDEX hangfire.ix_hangfire_counter_key;
       hangfire            postgres    false    210            Q           1259    51220    ix_hangfire_hash_expireat    INDEX     P   CREATE INDEX ix_hangfire_hash_expireat ON hangfire.hash USING btree (expireat);
 /   DROP INDEX hangfire.ix_hangfire_hash_expireat;
       hangfire            postgres    false    212            R           1259    51221    ix_hangfire_job_expireat    INDEX     N   CREATE INDEX ix_hangfire_job_expireat ON hangfire.job USING btree (expireat);
 .   DROP INDEX hangfire.ix_hangfire_job_expireat;
       hangfire            postgres    false    214            S           1259    51222    ix_hangfire_job_statename    INDEX     P   CREATE INDEX ix_hangfire_job_statename ON hangfire.job USING btree (statename);
 /   DROP INDEX hangfire.ix_hangfire_job_statename;
       hangfire            postgres    false    214            V           1259    51223 %   ix_hangfire_jobparameter_jobidandname    INDEX     g   CREATE INDEX ix_hangfire_jobparameter_jobidandname ON hangfire.jobparameter USING btree (jobid, name);
 ;   DROP INDEX hangfire.ix_hangfire_jobparameter_jobidandname;
       hangfire            postgres    false    216    216            Y           1259    51224 "   ix_hangfire_jobqueue_jobidandqueue    INDEX     a   CREATE INDEX ix_hangfire_jobqueue_jobidandqueue ON hangfire.jobqueue USING btree (jobid, queue);
 8   DROP INDEX hangfire.ix_hangfire_jobqueue_jobidandqueue;
       hangfire            postgres    false    218    218            Z           1259    51225 &   ix_hangfire_jobqueue_queueandfetchedat    INDEX     i   CREATE INDEX ix_hangfire_jobqueue_queueandfetchedat ON hangfire.jobqueue USING btree (queue, fetchedat);
 <   DROP INDEX hangfire.ix_hangfire_jobqueue_queueandfetchedat;
       hangfire            postgres    false    218    218            ^           1259    51226    ix_hangfire_list_expireat    INDEX     P   CREATE INDEX ix_hangfire_list_expireat ON hangfire.list USING btree (expireat);
 /   DROP INDEX hangfire.ix_hangfire_list_expireat;
       hangfire            postgres    false    220            g           1259    51227    ix_hangfire_set_expireat    INDEX     N   CREATE INDEX ix_hangfire_set_expireat ON hangfire.set USING btree (expireat);
 .   DROP INDEX hangfire.ix_hangfire_set_expireat;
       hangfire            postgres    false    225            h           1259    51228    ix_hangfire_set_key_score    INDEX     Q   CREATE INDEX ix_hangfire_set_key_score ON hangfire.set USING btree (key, score);
 /   DROP INDEX hangfire.ix_hangfire_set_key_score;
       hangfire            postgres    false    225    225            m           1259    51229    ix_hangfire_state_jobid    INDEX     L   CREATE INDEX ix_hangfire_state_jobid ON hangfire.state USING btree (jobid);
 -   DROP INDEX hangfire.ix_hangfire_state_jobid;
       hangfire            postgres    false    227            ]           1259    51230    jobqueue_queue_fetchat_jobid    INDEX     f   CREATE INDEX jobqueue_queue_fetchat_jobid ON hangfire.jobqueue USING btree (queue, fetchedat, jobid);
 2   DROP INDEX hangfire.jobqueue_queue_fetchat_jobid;
       hangfire            postgres    false    218    218    218            �           1259    51231    fki_Fk_OfficeId    INDEX     O   CREATE INDEX "fki_Fk_OfficeId" ON public."UserRoles" USING btree ("OfficeId");
 %   DROP INDEX public."fki_Fk_OfficeId";
       public            postgres    false    251            �           1259    51232    fki_Fk_UserId_OfficeId    INDEX     V   CREATE INDEX "fki_Fk_UserId_OfficeId" ON public."UserRoles" USING btree ("OfficeId");
 ,   DROP INDEX public."fki_Fk_UserId_OfficeId";
       public            postgres    false    251            �           1259    51233    fki_Fk_UserId_PositionId    INDEX     Z   CREATE INDEX "fki_Fk_UserId_PositionId" ON public."UserRoles" USING btree ("PositionId");
 .   DROP INDEX public."fki_Fk_UserId_PositionId";
       public            postgres    false    251            �           2606    51234 $   jobparameter jobparameter_jobid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY hangfire.jobparameter
    ADD CONSTRAINT jobparameter_jobid_fkey FOREIGN KEY (jobid) REFERENCES hangfire.job(id) ON UPDATE CASCADE ON DELETE CASCADE;
 P   ALTER TABLE ONLY hangfire.jobparameter DROP CONSTRAINT jobparameter_jobid_fkey;
       hangfire          postgres    false    214    216    3413            �           2606    51239    state state_jobid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY hangfire.state
    ADD CONSTRAINT state_jobid_fkey FOREIGN KEY (jobid) REFERENCES hangfire.job(id) ON UPDATE CASCADE ON DELETE CASCADE;
 B   ALTER TABLE ONLY hangfire.state DROP CONSTRAINT state_jobid_fkey;
       hangfire          postgres    false    3413    227    214            �           2606    51584    Document GroupDocId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Document"
    ADD CONSTRAINT "GroupDocId" FOREIGN KEY ("GroupDocId") REFERENCES public."GroupDocuments"("GroupDocId");
 A   ALTER TABLE ONLY public."Document" DROP CONSTRAINT "GroupDocId";
       public          postgres    false    3457    237    261            �           2606    51589    Document PatternDocId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Document"
    ADD CONSTRAINT "PatternDocId" FOREIGN KEY ("PatternDocId") REFERENCES public."PatternDocument"("PatternDocId");
 C   ALTER TABLE ONLY public."Document" DROP CONSTRAINT "PatternDocId";
       public          postgres    false    3467    261    242            P   �	  x��[[��H��N���|�1'��`�,0������Q�h��pHL2d��ۯ���u����y}����ƅ����}����ߋ��nTV�2/�g�66���{�}�r3�e�ct�ظ��������[��Ji�P�v�����XZ�e�ܘV*�
/�����b��x��K�0���Xm�����]�K��h]�j�+�� /�����u��¥�Y�v��S���ia�z��u�Hg&71�H��GP#D�H�m��-҂L~<!�Y@�6D*���B�Ӌ�=Xu̟��nOM+��A�������0��?�ܹ!X�tV��چ���7����W�H	���M=5Z����<� R�1~������bȪT��օ9u�ȩRV��U����nP�@ ??q�Y1VjV�X4Ѿ�AQ��|���㪣P�ERS=)�T�D#١,
�Z�v��ċ.�ȉ*�0�<R�G�����ډz| �sp���&߈�v:�x�r~Rw�&��t�R��vI-���R�<q�2��ِ�5���� ��h�#�B��>ʫ ������GV�1�jG��D�~��3
�'�?tL���|���H$^�%�n�L�>*���D|�J$�'o+���]z"��L)T����2F�(FJ�ί�t��'����F��*�*�YK)�\)�)-��a���"q<y�>�4�(�H4�>����
���A}vJ�Fn> ���jB��iN�9��Vkj�ٰ0�� �A>��>�^9�/�D	��kt�����(!T�l��}�b�d9�P�aC/�/���.��g�,f/y>�.S�����
X��(��R�ܦ�Q�T�Z
W�r�"lEf��c�j]^V��y�t��BJA�ւX]b1@�y�Đ�V��h`��hؼ�v#ob��D�oT��y�M����-�������a6_��X�v���lp�)q~�UL}58��m�TVx��h
hD�l�8��7�=y_�4��U��5����|�u ��}/s�R�XE.�l���=\�Sՠ:-����DV�z���7\o�EJ�D9|Z�r4P�"L�U`'t4̏��F8��Ǣ�ʔ���,�1>E#+Ǣ�J�=y���1`��?Rی���eJ�.N���6��<]�r�����@[Z4�3?�����M��g��_n�R)��骋Fk�p��-1O�hp����K���~�$Ў̢�s[T*cb�o�Jɩ-��FH�MHW#]�
�����"?#�U�Vab�h���t%�*�|r敨���M�^���c��Q�ȏ~9�&���ɨ�]bj�i�'f��m� +K�9y���6�ݻ�"��:�%���.�ю��5Hk/�5Ǧ����0�XI�$�`��P���w�P66!��d�7F̶X4�B�`��C�����ձ�(X���h!z��9�)w�������u�H%�h��V�:o�ּ�B�+&B�}W#�V�ցM�Ɓ��/��_o�P+)��Fm7zG�7:�3o�{��F�
����+q��9����`)�J�����*��#N`��+bm�ݣ��i
�܇��N�r{�-X���v$f�w���*�3r�̙��MM�v|F���o dv�Ե���F�UA���+u�7)_����8�;o;x3k����:(0����K�Ţ�N�0���	� ���۱�!#�E��y�Q�����DJ��8k��/�-��/e|<�;�����q�F�?�¿�����-A�E_B]>���5�F ���T���%��3j��7x"j����(���H!`�2|����Fg���;<��O�y���8g`��5Ϸ���ߨ�V���ɿQ�T��� uZQ�A��Z'�OH�A�WE�/���3ko`��GuklhpΨ�S�DS8�[�m"���ʺ
�;��w����}P�+�o��wx.�ݻ���w������ngN��w�Ľ������(��}A��I7�x�'��o�]�E�u��7����P��e�B�vt�y���j���Z;��0��h#uI]���g�c�<h:�V��sj���O�L5����1�%����+���P@�'_܇�PO>��ި�O�/�-.�wx.�SD���x�<��"z���4�Qk騎VD}�?߫��b

�M1�/#�i*��u8��h��Z��g�ӗ�Ѭ�d��*�v=���h�'��k����R�n^��Mvx��ziEr��\��n�em�'=��;��"'O����e�Z����
)MK�����m���>�u>��ۼu����g]�B�G	5��O�y��O	)o����R���z�6x;~b����;9�ބ�#%�<���ؾ�������0��):Y�ѧ���|�."�z�&���Z�s����<��<SSJR`��8�xJ�e��4�;���yB9��"�z����Zx�tJ��8��2��W���^��y�S�)3ņ	��Ί�����������~��̏���,��g�0      R   �  x��]o�0���_Y��2��B�]ʦ.S[�M�IK"Յ��+�3s�U��3�,ݚ���-���9_�qD4���B�?�RW���9��cY�K��x~ 4�?��\���R(
�xdzL�N��!�%�@2��e�ηǝ��TF�8O^ߚw!n1��"�A�C�[����1�;a,�ZpT��A^�Zds�d��xU ,�}�r�r6�u�A�]�df�t0�O�3gt�K(p'��J�D�S,�Gy��a:�p�s�k��kpL��H9
%�#��9$7��Vmx�ɔP���(�e���Tv��Y��bbx��Ǧ{�mH4p�l���a�GA���Ǟ��u�if��k�Oj�rv+�*���\�]?�I(�5�~F���㕹-��!/�˽Y]�_�^컾���ۏǚnTiT�m�ߔu�;#�x�{XG4��^
F&N�ˢ���l�q[mm��'N�������(t�c]V��n��N���c���      T   "  x���oGǟ7:�Vc�gƾ7~��T�P�!��S�'�;z� !��^���^��.�ăy�������߱�5L�^��v�Yw�|�������g/��?כw����W/��n�ay�]���r�]o~Y���^n�'���y�~��v�����[�NN>����z�����^��[���_-6��n�m�[^��G�ǳ�����������._�t��n��+��������e���\��q�3�i�o��{������2��}�����t�]�W�����E��mw��������,��x�m]^m5�YX\<�V�fq�l}�j��O���r�����b��{�\��ss����n��(w9�<;i�!>x����<��Iˎ�KȻ[!�Hи`��a�?� |�&�E<��JL�� ��ց��/�x��Tl2f�\�Xq&�/���3�lB�t9#�$�;ɲ��ǊYT̼af�r,^�����8�BWR���et��2C>��~k�W	��އ��4�c���5/,�'D�!^%��X�b�/�`�1�A_�� $e��)fV�0̦`FE�(��8�bq��2f���af�r4^c��b5�tղ�`�dIS�)���RBN��Ր*eC�'J��a63psWE�AL�6f_C����xU32�,Y�V1�v���(��B�0`�П��et��xAA#��"�{j9:��釆�3�2�F�W`p���k(&.,����5�zq+��}��y�-#Dh�9+��ß��Ҫ��|yg �b�T�Tl\��ԲW��i�[k5,)]V�0�NY��m��6e���4�Ci�M�deV�U�4<Y		FR�˘�bfs�+���>y�/�PΓ��Y��2�����ۈ¸C��b�)2I�qH�j�F�޵�"P.B��1��ZSB,#��2�olzI����Ր�#�Y�@s���ɹ2!b�C��ä�ڗ,��,WZ�ܻ�Z�5BJ;N�ϕ�\*�]�+]F׸�>	J����N�*�#'���,EN7��w�F5.�P��o8�d�a6ŉQ�3�ߩ��H�"f ����e��G�a�>��[�F�ͺ���΢&�4i�9+!�"gЈ�*�a6ś�# �N#��$e��k�q���0�Ir�̓oE(��d�j��7�k��wǔE�,*�M�1����_��S� !�!^�^Z���H�A����&c���v*}�'ƚ$��Y��Tl�$K&�0<I֐��a�а�LŦc&@xf�I�IḒ�`�J���a�k^.%��E��ȩ��0?�Mlt]#��Q_:���>?���J(��#-GN��K�>&�jky�<�zz���ogߑ-%���g%^ʾH�D+�fS
e����y?,\p]&����k�;y��)Kq^|�)�I3]^MF+\_{�ʃ��$�K�v��M�л���`f̲���s;�<}(�8�	�h�<F�5���}=�@�j�\��=QT̜5��)b�J��(ѰۇR��}Y�	f�͒�MW��r��Z�q���.ӈ>���.L�&s&���Y
�)�\�P�f*f*6��O�s��b=W�Fxp����t��=�xw#�I~�I���j�����R�0��f���<�Ai�{=Fz͑?/����w���7ǿ�����Ad�	����Z�Q�=D>�ձE�v��J2�a����6e�.�e4Φ�V��Bj�x�Ya��%(�lrJ��-+��1:��wo�!R�AG�l�=�mt��.L���P���'ً�lt�m)"�{�Z�A�rKQl�����#���y�>�����|`S���wT�1/2�k$)�������      V   1  x���Oo�6�ϓ��{I�?�(�����zI��6@v��L
��W|�tC�"_罼�Y�E��V�!v:�z||;��N_~~��ӟ�ۻ�N_��/����};�������t<?<������x��r~y<��ޟ�.��p�
!鷧��C��[,���n����ޞ/o����x�����E�?Y�:,y�sIiH�;����d�aX�kY#�4g%A�欤6�ԣήe-H�+��i��(�hӌ��ccP�[���I-��n�$�9nL(��Y���z��Z����CqYL�>��a���I��fp�e�s�A�`s�zp�]��J��X�8�Ml�QN��%#Is���� e���6��,���=K
!�b�PƢ6��c�Ｏ%7$i�����dm�8{�z���%%"�#c	�&c�6��c���P��94(��ش�f�Z������#����6g��`rF��L�YR)����3��h��(���;�k�,���dm09S8�0�{����3AIP�i�͘�e�Ｏe*H�8+��i��هe��,)�͘r��mF��`2��c���!���P΢6��cv��Ԑ��.�����`2f��3O�IgNP�93i��)���=� E3�0V(c��Q�K�Ɍ$��(ۜ%j��Y�ӽ�R4c]����8�ElF��.��4$Y�����`r�I?���SR4c�l�+A�f�YlƱ�q��S+�,�����`rvɐ��r�����t9�U��v���|]�����p���"R�vx�%(��H�mR�]X+H�8+��i���r�II/q�_������3_�7��= E_c�=Bپ�����Ť8�����dq(g�{�Gz�]K��bZ�e+��)�t;���q���5�f�XʹK;eB�ř�8�E�ZU��f˱;��%˱;�r_�<��͝;R􊥥i2Cپ����� �ߣ�sHH��Ɂ�8�Y�0�����P����Y���<�,�M�� ���B�TH�F��,L��,k���:�8Qp�H28G�e�3�6��2)���L1_�x�׸^7��A�c�v���Ċ}���^��s�]�H��8Q��LIdq���(Xޓ$�D!�`�ݝX�Ŵޝ䥜(�� ʟ�6>��i��*@^$��Hn�c������Aj&'C���o|2M'���:������جy��\
k��)S3Mo�2X�zӕ� 
A�f����MW�f�eӕᚢ�٠8�]LN��hz����V�e�>$�2y������25�.���D&g��p6m09�E�[����d� ��hzp�!�V�C���Gc��2�ؕ	��8��TL����`?p|��׸`;���>T�J�2f������p"�5M�'��i՞z�8��tM^{�!���$c6��?�g���,c5鎕��׊(��^��F�b���� M��d(ۜ2��6e:��/>Xh�-3�;����L���o�2�=��`9w�`r6(g��3H��'#&"FS��_H	�&�p�vlp�5�{|�1�
�L�
�cmڱ�گ�grM1�s9�� 9�2:f�}�Tf��?F!�d͐<֢�������ݨe      X      x������ � �      Z      x������ � �      \      x������ � �      ]      x�34�����       ^   �   x�E�;�0 й9�L*;q���$$>CD��B��L�����^�MS,z�a�8�NC�6dr���62uV1G�C l�p���.۹>��5�V}��!i�u*p]þĥh��8t�Y�d�A[���'�4^�(>����=5h.�1���+�      _   f   x�341�,JM.-*��K���O*�443��02730�t�H�KO.I,)-v,((�/K�qO�K-J�q�O.�M�+	(�ON-.���4�241��i�y�%c���� �Y6�      a      x���߲ɑ�y��0^Qf�c��GW��h�k�Ermox��ۄ�Z z���5����("2� ��Uu*d�x����9����<=�����w����4�4������������W��w�^����{۾z��e��ax������W��]z`���w�ϯ�_���z������S��W��W��|��}?��O?|������;r�}�=|H��-�}�����޿����ؠ0����݇�-A��8�������������0t�Α�Ƕol��h���#v�AnL3�-{?�)��+����:����]�F4�Xo���y6�]��"61�A���a��J
1�u H%��O~�r�~?�߾�[�~�ӻ���oʟ�1��rHo����f�g�^��K���Zא	���ŉ5��|�W\C�6�k�-��>��)[W�
�>Z~֕�~+����x+p�a�:�6D�ױ��ױ<0�K������q�5}׀��똠m��i"E���������|�K?E�m�".�͕tAZI�g�������ﾒL���ُ��4*������n�����qG,A0�xG�0@�#���g�P�it)�-����n���^�O�BHk��r%?�B�w6��r���/���󢉷�Չ�4�`gA�Z�&N}-]�� ��M?80�2���I܎�<x�b3Gk[W���G�*�0X�Z���X��t�S���Az
䝟?/"U6/�d#o���X���D��y
m�}��M�������s���%LM��a��|+�+I!����$>O�V�X�|=����������~غj�f�o���P�v6���6���~�t��n�9:�M�G9���V�2v�O�*$�����,>l��FXLD�����	ҴΛַ\���1�uΦ�m��E�R`��JƐ�2�7b�.���)5�_L�/p#6�R�i���|�7b7�m��Ƕif��%P�[w��|KwC	���='�ئ��g�v�ܦmYf���D�Or���X|K��A l�������V67�d#�m4F1��߉1R����c2�`hļ�ZOC`�w0_D�Or�.y�D�%��aFq%}�ጕ��V�J���JƱ�0�.߀m��n���5���������u;�A�,ޥۡ�ݹ�ۻ�6�<m;K��i;��������X��e�߲�p�� �����b�asM6|d/܊�DUw�J�cy�_�8��� ����ĕ���+�6XA����x��G��a�v����b��!����v��t�uO�1ș�b:�3���@(���t�r�}*	⒳X�@lS�\�@�W'Nl�b#䇹�o������>-v�5�q����1�e�cc�̀6����Y~m�d
3Z���RF1��:q�R&/�i5�ޤ�&�΍���c��B1��a�Coog�B�۷����%�B�-Y'1��W~)C�x��"d�pa�AP��W�m�}�51H��/��9.� �>�;�f�����	��0�������S��7Q�K�,�P��� m��&|
I�:Ն��ef,���>}ٹ�St�so�׭x�f�(관�X�v��1B6uEަ8�=<d�#�P�C��و�^��xr!:)�Q|H ������&�9�5W��r3�`���7��ϻ�ҺքЅ���5)~��2��/v��}�:l��RG�A[7���e�"֋y^��i�6d����8�z��
�~4-��i]̚��o�Tb:�Zl�9�P�b��9���������?�8��HuOX��� ܰ��=�����ˑ���n|��%c�A(�����sH6��+�}�����)�{����N�hBx�~����ߏy��<#
t����Bm|=�8��@ihL��o]o2����^c�|jgZKP���1�����vG�0�F��g�q~$�+x�m�QR��l�*[��pE���o� �m 1�Y��b�Շ�Tmp^y'@j6�57���.��c��}��e�0%7̮���<ЯH�|e�(AF3�+IՇ3V�����XL����W��]���A������}�iaX^i$��a�v���_~N�J�����V����l]�Ӷ�w^�b��嗋��p�����j��U��QaaI-��"������+k�h=�WM��{�/~/Ry��fo.Z�e
$Io$Ο�+�Շ3Vұ*&�	���8���'������$�3�����D���4(���u?LA@�f�j+ax�x�}��V��
�a�Tmm��9��;�e���u�Wլ�1��-���DՇ�4�H�C�����H}�j�D�tK�/8Ӷ<���и4r�3WQy�_��Y��bNȣNa�5�Շ3V�-J�b����1�!����4߀��l���c������_�j������T��Y����/ť�}݉��y�C6��7����?�y��+W0_���z��k_�_}��P.�ú����ޘ~��n��?.�����������=��Ϳ6?���s6W]�c���?��|_~�Oy��տ������ß�5o�7]u�/��W�ۿ��Ð��x��ë��޼}���7y����}��0<|�+;|Ⱦ�?Ñ�WW������o^�z�|���/~��?�e���������;�����ڦ��������ͫ���o�����������ux����<3�ϯ�wo߿?<���?���5�G���������o��u��0�|���o��_ߐ�/�m����o~���]�����<�������~�H�^��i��^���?z�6o�����o�v�S�������M����������<|�Ἣ����W�}�s�+��O�?�Z�a���@��b���9��Eܽ�����U����u�����P>����t�Ϳ������������_�O���>�M�v�a�>��_ݫ7��<s��ǹ�t��]�����G�����ݚ�����
'�ξ<L޾}��|?�~7�������J�o�_�nv"[�_����R�T������O��>uz�"��O���oC~����L#�S�������O��y�������y��vh*@�/o?����ϼ������ ��8n������|Ȗ���T�Lt92�����[G�Z�����7�Zw>'/X�7TP�-��C��m�(s{��,&�T`��$���sP��1�$p{6��+��c�`"�S���v�m��\��&4][����pRZ��*��� .$)���Gp�*2]wg�����d_R_��,��v~�׊}t���e,���,/}Aбkl��Mk��?�#F��^�|�c��qq�_�K��n�`z�"HE�A,�Rt?�Wa܀�*�T]$�Ҧ�����V����>e�dv�"(���+$��An�� �,������ɣ��دrg�'h�]��@��;�;�ǹ�B���ܩ�yw�u��	{r�V1|z��[a��%�,����λ�ά��Uu�Pjj�g'�����u�Vf�x�����n����U�2��A,�.6�|�o������$�~��^Sؿ0���v�P7�f�Er$�!�m�y>�l;�f���:7�6@2M��mlC7�.8#��w�pt�D�ĥ8��T/ŎZn���ֵ\��^��j��XV-�Z�~�;�P�U˩��H�Q��RH5�U��OO<c�X�U�Z��W�����!�G�
I*���;��YUPΞ�1��6H2&���H��6�h" �7��ф&k -��8G��~Rcf��� ���`WvVv>�eege��q�`z.*;+;_���o��}ٹ���ut��6��j���k�xr:��|9;,�sJR;KvxN�����,5')&�����{g�>����)��c�����a�"�x�1siK$$���J
�
χ����|?��Lo�E�g���9n&�w-^�ѪT��i��y-����g��Y/�fV�S�t��'>xa�N5�5<�K7�s�����j������Z�zĕ�~bى����b�ɉ��&�N�qRc�Whg1]�m�t�KQ�=�Y���2Be�    �8w\F�UF���DFx�)#v=�0�Y
��H�Ӑ�5Q�+���n_ׯ��I�>Sl�:�������))�m���]d&�w������EEpc�u�'R�=�=zl����Q���MX��2W^IqX{�>���2��+���q�+j[�B� �Xq�Kx	.<�>֭���<뭀��Ne�ʠ�XV�2�~�;�ƸU��H�
P_��B+t@�E�ķ)����t>%i�H9��N���Ӆ��t��9��8�˭�L�&z�w�6f Hc��N�uvoh4Ŝ,�@�9�J�J�Ǳ����|?�Mo�E�盦g�����¾�\���Y��z�s�	T��m8'���E���P"���w�w�5`�?���co�/���Ωh*\�-HQ0p�3{ǐ�8��c�Κ&��t�ņ�m�n~�~��YJ�\'dFiy�P(Ͷc��3��#B�q]d�Pp˪T܏s��pQ5�j��4@�̠�zaF���Ԕ!2�MMy�����
YGf'��-h��0��,)&8&�Y,�}>ͺL�a6��aw�W�)�TC�#�P.�����6��s� ��QX������1�d	֏��>ߝ٢����v�8U�m]�)�Ď�%/�>	9���}�fvUW�裸+m�����u���f���x��_��,�1oQ�|�9�8�6ل-5MX^�a�a���{'H��j���~Շ3V��%��l1��P:�����Q� �1�xG�{�G�Uǳ�T��J~�4�u%_�DU��cY��*��q�2�\T%�J�%�T����h�1���MY�A=����y�O'�yC�!e�c���}:���Qt�Ђ�)�*��H�������r�=T��۟�K�)�VX��rJ�J�Ǳ����|?�Mo�E�g��K�9�Mz��=،V�(���@6I�\�+���:zN��������ξl�x��'�����j��?Nm�m�N&5����d�a�7�>��H����)� ��NX��R�jSzVz>�e�g���q�hz.*=+=_D�q��wmG5�U�K�g��O�yW�9�O'�K�A��p�j*<��
��<T-P�a��'1�0V����jߪ�*�,~�c%c飴��Q<�m�ጕ$p�DM5�NԜ?�:B�b���\�*kLb	N}5���U�7�3�$�[�PV���G��t���:l��Lu���+�dU��;�e�a*��ǹ�j�pQe�ʰKdX����J	��Β$���(ʰz�fv;�}DSq��
�F�Ȭ�w ��}�}���q��\T�S��&��Z�2�aZ��\>��}������S�\�qd��S��=��>{��B�R3�3ǩ�
Ӟ����2z����D�=|�F��m����Ζ�$~����R�T.���#�?�M��]e��z|�,��C-�� �����YV1�b�~�;.�߀�*FT�\"F�nv��;���";!	�? q4]%�e4]������q�NU7���(�i:�l]o��g�!R jgI�t=>�!� T9@���z���a02h)ǃ�`�������|�!��/���r�W�C��N{�(�Ȳ2�2��8w\������/a�6_�Z�?����;^<�Z��/��5���A����#
䚥�o�����]3�%�lĮ�b)!G���z �J�J����q��\TzUz��^�W��e�3Z%�X��Q�b��5W1S<9Tw�W��x����{�X2J;�^��c��z���HP��@�^^�ǹ������z��f��@��:�f�� �^k�Üze�?iY��)8�ֹ���*�Ȳr�r��8w\������.*{�ͤ�g�������I�Z�+��Ԗ�ӧ�|I���vf[I[��`��r�!�H����jbCP�"S�b�85ٽ;HO19ZX@9/����|ˊϊ����q��\T|V|��b�mv��3m:�X���˭�*y�/����c��ނR�"w&�$v�N���3*f������'����[hS�&��>xCMMh���7�A�j��ϓbA~=�\�y/��YVzVz�王�7�ҳ����	�+A}��ٙ��p�"�zR�z=U��z�kc��r�)D��aOǟև]�g�.\�M���0�WxR��Z�k�a�v��N��MB9�&�|yx:�s�G5�}�?� x��1�!�d�X�?���	�3�`�ah���[p�n�4�&@m.��������U��Wq�����cy����+�9�]A��Y�	���<�FE����XV�"�~�;�B�Uĩ�����6+��lڱ�U�O���J��Vn��|:��W��Lr�/5<����4If���r;���.e��G�CY�)x*xǲ�����8w\��<</{{�7�o��o!��:yF�����|:���ޝS��m
B�Ky��/9;���;�0�ނLQ@���[�Z�b�}g�n�r���.�����C��H�Νs���t� ��_�¹�oW��^�T��u����1!*BdYE����q.�Qr�q�Y´�ډ�22'��	��QL����U�@A��E���c-�:�.����P�Sl�/P>ұk��s���O���X��<q?F^{׏LAS"Xo�]bNI	Z	�8������ǹ������}A���][NlŖ�4~�2E$�^���o�.='k�.SœԼ%;�W��]`�&�ש�rܻ�g���LA8�Pl��=x. x_�c��0�����!�`-�?|��VB��0^��\�䑝����8�xZЅj��n�x�����v8wR����iemnU��[ �OtG���N��8w\�t.��SAw���ۯDv=0��O� ��69�,���R����>;1T�����!�YV�S��KU7ࢂ���e�=�}ׂ���8E�(h&�T{%��O)���:}7�+ԗ��{9}Z2�^N�kŖ�ى�:�p�9��?�̲\�8�w΁�ڳg��ʭڡL�Z�;l� ��.�'\���tG������Q>��AQ^Q�8����ǹ�r���(�(ʃ��U:s�l���)S�ؙ��,�W��:�:��z�S8�Z%��R�ۏ�R��q<���ꖬO�J�Re�?=���}�ɤ������4Πn�}"ꗾ����t�1�O�*1��Pz>�e�g���q�hz.*=+=_F�q��w=:�"	SU��)Z��3zť���j�C�<�2�%��J�PN��&��H��	]l�#���{Oc�LӇRRzC#q4P߷0,a��=MY#�t�9iSq%�YV�V��王�7���E�v��w�!�ي����|(m��z�RJ��C����KmU�	�(�G]_������|*�tg���JH���;�G�ql�r�����?���Y��c�4K.��� k�T�fև���jgDE�YV�W�����7�"�"�e7����ef�h�jp���$xA/�$�q����w�`}0O%?M�*�Ȳ�����8w\������.#�푐���ي(��rr��S򶼶�fB�y/���-���d]��d��N$f�#;��s�!Օ�L��G��R�Z�y^��{��8���h���Pj���u��p��a�	cZ��W��(K�k��o�D�i{gpH�imGf�R�ev\�I��[�0�#o�A��m���MS���`� �4=�݇6��[z5vV5ho9E19�z�Uu�ꪃXV]���~�;�h�UW���HW� �UeNh�<��Q\���*����w���u(s6��G8�Yee����74��0�ʱDbK�"s�ܥ=���[\�l-��.�R�=�e�^���q�Ly.*�*�^����������*z��t�@�E����@�h���
�L�><x��Io"��7	�]����7 �=���y��B�����6��[_p�3^9Yg1�ocJ��b#�~�1	�0h����m�}eb8}�w#MC��0����Nĸ����&����Ĝ���
�YVA���~�;�Z�UЩ��D�9W    �z{p(�����I�~����r�����b�ˑ��D+��´/?�;;<o�'Y��*� {��e���UV>�ea��qy.*+_�f#�曍]���l�#
�6D��Q���Q��+�I~�/�7�V�&̠��i��@�w��z-N5��8J���Ī�z?�o�E%V%֋�5m�ڵ���V�:��2�1n�-!��)�N�R�QA��F��s1a�N�g#�0	�����;��Ԣ��\�a��&�&4M�Z蛥�#�r���Z&�A�-�q&'�e�N����"{y-����.8��Rc�hD���O���(qp��U�gg#�r.#źw�Cӊ3SZ�tT��ʡYV9�r�~�;�ָU��LQ%��r"w�@@���{O�V�z"?ސCg���#V�vV�B)�D���=G
#l��`�ؠ���_P�NYѹ��1�|M��ѷ�c��yc�u�fؒ� +kZr�k�|��1��W*���s�!TCǲj����q�\T��"A~SC�z�yb+bW��N,����V�=��/�����t�?�g~���`,d�RFx�-]���]��S<=�j
�E넗2%���1�!���m�Y��H��1���wv����UMAcm����9f@�p���XVW���7�r�r�E�vs^ծSf����;� X���^��M�y�X���z�Hh��e,��� ֡g�A�P�%�_�8��Ȕ����b�%ل-5M�i��TU��)�9�k�{��YVW���7�r�r�e�p��U��n�t�4��xĠr�rĀ�l�ɵ��3Y�J1�/w�g�M�d����D�eM�>&j
:9��s�J�Q3�J����}?�Oo�E%h%��2��s�v=�;�+T����LvA/^��5Z�Z��4�)e�bCE��t���H����b��?T�c�`��� c�	H�'H{��ҡ���mn���!9�3)A+AȲ���8w\<�����/#h�ls�k-��Vh?m�i�R�	���A_y��k><9뤶,��$�$�g�뜍P�(t����AG�ed�1�Eö��s�z��t���k�hc�A�Y�8��dY	Z	�~�;.�ހ�J�J����ۧwmm>�U6)�j$D�(4����w�>�f���l͉�g+M֡l�L�X�81 �Vr $e���̖#t)z3p,�2�`Z���ǘ���/a�|>ﱖH>J���)N)r6V'�X�@P۰k�W$�Su6�-��"��N �*HJ�1� QAr�*HT�܏sǥ�pQ�
��	U����
EA�67_$��[��ʯ�s1N%)k���b�pz� ��	�vC�1`t�jm�RA� r{���9B���B��2)�����u�ۚ>p�::�PAK��똍�3�W)����lI�6._L�_u)�X�&��I%�J��XV	��~�;�>�U¨��H¸�)a�����$t�g�w*�`y����34{����U���w�J~J~���q��\T�S���f5͞':��ד�d��ܛ���қ��ɖ$ઽ�T��. �����'j3��v��˞a8�g�.�,9ow�\NAS^)\�s�ԥ�,+�*�ޏsǥ�pQV�"�����iO���*�OߖW�#y	`z��e�wNW�L�Q(@(��a�����G2~,=��Yӄޙn��0��������GKv���7���p�d�)l���0�LN �V�;ʉtȗέ���1kUN��8�e�*'�ǹ����rB��Er����>����2���c�b+����;��^�N^���"5���J~����w?��n�E%?%��ɰ��z��|[cX'?��X	Q��iJ#�D�'���<��A<��:�u�p��� �%,F��򳳄�)��X�3p�c���Q=��+��q`�W:�B­�OrW����i_��ztq�-����,+�+�ߏs�%�pQ�_�������Uzx�l�����0�U$���w��m���h}�a1�I�O��8������ǹ�b�����w���l}�g;���ׇ�'�)ذ��?,~�k��!d_�:q
�Ť#���_g;��@�zf�8S�!�S�[�Df��r��/�n�q�0ԧ�`����6&9�c�Ʊ�f	�:�@�d#��O2&�~dJ��r�q0m�	[j� i	#쟃�AGb�H
���X�ȁ,�Q!r?���o�E"*D."q�Tn(�.��(�� ���dY	J	�~�;.�܀�JPJP�T�|��kۙ�2D	� RS�%y��:� �k��o�(�9s�E�M��!x�Lp��Ռ�R�1��xQ� ��3�g#	�NL�e��H_��FǮ��3�Mk��?�#Fc)3�'�ǸTpw]&}�
�P>�(��?�����zPZG��S!���-�jtYkaT@ɲ
(P���q����J�E*�f3�]�@Nh�<��^z�%J�_�O�/���w)�wQ�̳����q,+�)�ݏs�ŪpQ�O��2򋛩�]��g��LRB
چ�*�^n��%��k~��*�[�?����S�Nl�O'#��"W~��س�\;��i�����L�#��qlC��Q:R�k	9����ĵ��:q�Z�q��dc�Tt�-��E�`��&�&4y5��7�F��8>�#���=霍(�c*CO��ã�7b
�V௬��K�^�����`,d�Rc���&fg��\��vTv��ɏ�ZV^�N=|��N��A,��Sew?�W6݀���T�]�좯�U:��l���&��R[�	����Ulu��%漏��WF����g-�R�qCV�����߳��bENv�eI�9��q����F��
��hk,b'�(� @JR��qt�Ip�<jl!�$i����7=h��J��T��b�nUK���Q���dY��j��q�B�\T-�Z�"-���W4�U�$�G�䒕�D�*���Ϣ푡=���������dY�O��~�;.V݀�J~J~�e��f}ף�[ǵm��]Q����Ke|����"�]��ޓ���7j���슞ť��v���a򊞊�����y?���n�EEOE�˒���WI:�lEh=�A&/=3z�Og�q�C��;vb���cyŞ�P��߁,+�)�ݏs�ŪpQ�O��2���2w�8����i���V�z�g�b}M~��r.-Bt�h�ZXX�ד�d����&��Hr ��K�����~�:�l�Q��JC?���ӳqf#d�p����߲d��t����S8Y[�p��1�y��ƙ���c��L�1�@}��0��}�B�?�� �
��	�0�^��v�d��LlMC=�яnHԏ��Q��"7�O�ǰk�Z��0x��w.Q���oj����T�KgZ1�tnwuS�]�Z��r ��g���UN��>�Kٱ�㐯��`��7���ֆ�1����]��җ�ż�y'1��֩a��,mS	�n�?�����T�; P��
��XVa���~�;��U�0�HSػ�y&��^8�VJG%)AȲ���8w\<�����.#��Yϼk�Ǚ�(������P��X��~��6G%�ڡ|�0*)��P>�W�^N���U�cyE�ъo%�͟�/�tz2��G��Fm��o6�[;�C?��1�ޙl�1@���jڹ��{��w��WL9N/�`aW�8c-�F&U��Zv�O�6f����2��Ɓ�R�k�}�P���3Ep�"��e�ā,v��gMv�ζ}ݎ;���U��FkE�?AU����XV�*�~�;�D�Uũ��H��TW�Uz;�l�(I�cKՅ�PF��D~aC�QK���,�$%�]��,�{<G	e#"J���ѱ��9c!6�s�A�����fl]������T�X���ݻ�@GZ� ����ǹ����� }� �^
������}ƻ_?�1m���Z&hr<e��oD�@�
Km0�uң�Z	ţ��{ ��������I
��q������f�m��v.�`MC0#2�)�n����1GX�À��1�    ��2�>�hZtJ뇟˚��-R4?�eEsE��q��{.*���D��3�lV(�z�yf+r��g�ֳ��.��n�O���,���.S�v�e_�n�\�m��>�Xg=���`Xޮ��x���,>����5z��,�g5>��f�y���m|py�x�s%f}�O"��T�q!���u�h'����$�W��/F�����`S����n��bj����#F���ܐ��cCC&kɞ �k	�(�v�U%t�Z��6ֲ��	r(����B��:�kEEN���:�e�C*��ǹ�j�pQ�ʡ��P����������(�*mZ<�r(��_���t]�O�U8�H��|�-$c�+��N��P��-X�ԇ3M����;�v�k�	)&�]� ��i׶�I��>�|�F�h���<��R˻X8�¨	>y��H���y�.co�u����jF61�q�&���8�g���G� �$�ڀ� ɓ\_E�\�F2-Si T�ɸ��1��C��St�z��7`��/׶t�mx��5ס�0dQʮ��곖m�3��,f��(\�;jGM8�?rqU�����j�YVM���~�;��U�&�H:��U&C�l,�"c���UMXы~��-L��qw�m@*Ǟ�����cY�O��~�;.V݀�J~J~����<ްk�����M��׊����hz��������l-��.���bNJ~J~Ǳ���w?��n�E%?%����o���Z2�!
u ��86�W�t�;����#��^%PJЕ���dY�O��~�;.V݀�J~J~��_����z rf�d�
�h������_�:Wp_\�:�i�bK�`�<6�+A�&s;�R�,' ��wPW`G������ǲ"uȥ����A,+�*�ޏs��pQ�W�����X	�T:Nllda\�򸢊^a���v~�Y�1z	=c� ��\G��m镒��'���xA��@�==�ǹ�r�����o=�"�tS(h$1eڑ)'h����3����)����)\��R�̾�vՉ"KL�?I�m�:�u�|6Bd�V �m����4R���qh���{����c=����s��z������M[z����YƎh�KK<뉅SH�[�tz���,++ߏs���pQ���&�8+�9�}Ϭ��V�1�u���B<�T��/���Ԣ�6�:�'nuȧL� a�'n�������=�H,tq*6���-af��3���Aϣi�3�إ�醡�0RcW���`�0�$ Y����YV�V���˨7�b�b�eM������:�&��pt��3y�ҿJi��[�fW �̈́*�3�D~F[���bÁR:Xkiw~��m0����E��Ǽ5�7c�4�S\�a��a���%h�i�
?��lt�g��XV~V~���7����E����W)��*��Y�e�X����`�w������n^��y���m���n�	|H	'�n&{���]��R3D�����"�L��/6�)�D�`���̡�/5C�"E��'3��[y����͸�+R�k����d3���pm�R3 uj�de�]�V�R+)o�IK�S�fx�������`\=4�R+�3�w=�u	����L���������f(lE�a?�.O◚!@�a�t(oΒ�yx����j�a_�<{^�S��:'���H������OONԺ@�	�+�5�t6�bt�3J'�;��(M�|��P��r�����D��/Qp]�3�Ȼݱ�3s_EӺ��q0v��LZ��36�#v�M��Dm�g�̍�ҙ�><��랾�b��^�q���<��M�S\=��^���ڔ�>d��k�И�'g�F �.O�kk8ŀ6����0�&���Y�|�P)�:�w�\��m���_+	�V<�l��Ȳ��4w?�7�u.j.Nsq��"U����?�UO����p����1�3�.�5r��e/��/`��a�LU��l`YM&[ퟠ�b��V�V��#=��Jn~.1cb���C��| ��������q��\T~V~������g�/?�
6�jS������jB��FW	��go�/`� �6z��k ���vw�����<s��9f����)Zo���a�3�//jS����S��)�����h�XV�V���K�7���e 7z�ɨOl]��ɨ�RI�J ]�+-~�� �=��a>�$t
q��(�i���D /��~�R��{�3��`�sȤM��dYZ�~�;.�ހ�
�
�4�M��o��G�" �����	�x9JC�:��G���~^�R����O�dĻ���ņ��|�4 l^~���ӣ��.>�1�_�� ��/\��R�t^}���k�l�z�I�T����cY�_��~�;.U߀�
�
���?n�_��'��G�3�0�jfd���^��f*�5�|�C���3!��$e)^��X�؄��� ��{��\|3���d��6Z6cj�_D���2}W�i챔�h��5�qʍ݈�Zn�m���I�@��䃴��Ч��yC�%8�B�M��I�^H�5�K����~@\��3(/!?[B\�g%�p�.��` | I�3Xظ#�W/6/�d��ɵ"���,kquv��k����K�Չ3�2b���R�ݗґ�>p2��G�}�J.������/�9��c�`��|@��!(!'�����,k�@3���q�����\�!�X	�k�^�*D/N���N�z=�&�T�uK��S��P��N�*���$����{/��)��Q��y%����O���y����m��ݵ�o;�;7���i]��Z�:����%�ݛާ��2���+!'}���~ �J�J����q��\TzWz�����Mz��h��V@1	��%齠-~�k�/18�$P�(���@#	K ]Z(�~2��1u8�e�	ɴ `���5���9f��B�;G�:fH��@������ǹ��������|?�M~��d��Vy��3�3['�3����w��`ԡ�������X[�s���N����Ϳn�����`���8��U2j� ��%���`��2Ĺ�2d6�Я�;�l��e��~�Ў&�|�	�Ӵ�gC�Y�Plm\d��H�.>bz�AX�@6y�Ps��A�i�r�N�B�lݼ�U�:�eB*��ǹ㪌pQ��
�˄o�;
���h���"�";i�CE/�@��3�3n����V�//�'P�;�e?��q�Tu.*�)�]~63�{��Z�*X2��"��hB/^��&�}�R��)0ӽ�q�$�VN�n'#�����j�v?~A��Ž�J(����
Ў�u
�
��� � }?��No�E�h�� �6z�K[���i&V������]w���u.RJB{%Ȝ�87{s�g#���3[�b#�~�1u�0����v�5م�t]���k��((���0N1g��ش_tٳ�(@Ȳ���8w\:���/h�}�q�҃���c�U�F��ԣ��W�t��_U���܃w�F�x8��N�@{8Y�=�1I�b��f�xhL��`0b�'7&�Yd���	�ǝkw瘣%X/�(!�@+@Ȳ���8w\:���/�Y���虭Г_��b��-tA�����We��/�p�6�0"���t2=I�q�����!�.!�&5������z�]OX�k�(h��s`���iZ�@����ǹ����� � }@�fzO��تT-�qCb,e�+z�{Ez��J.%'�@�q���!2 �D��H�Y�>��ژƂ�	Э�2%!�Dt�p38�2���S�(���Cp�hX����ܢ��q,+@+@ߏsǥ�pQZ�"��Sg�&_`c��m�J�/��W"�?LBzy>��Gk!=$�.�*N��������ī�8���,! �c���T�dڶL��m���黥��=R�l�B�v5]v֪w�i��XV�V���˪7����e8�}��v�G?��'^�G�WI�GO���|4�g �  S��B��n��d>z6��OS!�C�����tڝ��S�m��%d:�\�@����ǹ����� � }@�۬��za�����9RE�^KE4^3�?<d'!�i>���� ���">	6���&���#F����`J/CC�JE4v---9pߩ�K�Hx�Da	I��������|?�No�E�g����y{,��<��g3�>�g�E��z-	h�f,"?z��@���Ǌ��&屈xj,ⓑ8���l�{O�H�!���L��}2�o�zA��Sz�qzK̜Wv�%G���W�>�eh��q�tz.*@+@_�����ݍ�?�U�a�Ha�@�I,>�-�����}�!y�`�c���������D�'#���*AΦo8V%�:��)漧2B�t	���r%h%�XV�V��王�7���E���G��
!C�*A��|Bzf�%��9h�J=I��tI�u���N�V&谝��hąZh�K��&��)�>��k;46�`�u�46���ކ������)觐c���@��#j��,+@+@ߏsǥ�pQZ�2��]S�K�	J�۰FP��EMA*AȲ���8w\<�����. �??������²      c   �
  x��[Ko��^3���BdVM<@]$1D:�7����-ұE�Z�"�b��uUL<A0Ƞ�i� E,Y(����s�%y/%�cuf��`��t�y|�9��Y��όŉHF:6r�T=���$3�1y�`�W�y�8��Y ��G+x�S*�q���~]�O>��
����p�bz���|z|�/���I=ǋ3!S��?���~�
��jv�L��*:x*�gQ���T�����Y?Wo&����
��A�a�(�E�7΄i��-Jc�\���q�Y��7�'���1�=�B�Ԛ1�h���[�`���3�Yр.���@�8C��D�+� ���
^^����&��f9�:�Y$�'3M8�D>�G�r�M�/������cFG�o<j�Ń�K&x��,��E���""�"��#��"|Rn��/�q�	�����)�"���
�7V΀��ߴ�{��j΄L����	Jo=L�ʋ�����I��1�Q"�E9��^�΄��&�[�x�U��1_Cҫf`�z2��ނi��s��<��߆�3�u��\�N8L+@X�Ӧ���E�1q ��f��*�_��x��l�`�>��+*2��A����Y�_�9�iqƲr�,��КQb�D���a��Iq^V��q�ufvڤ� .g�9"m�.e��>�$FO�i��m�@��g\�;�N/jW���hM&��X�mz�>|i���z���Jϖ��L��Δ���Ù�*�O)o2�>X��6hQ��$�㤜�)��r�����w2>�6LN���
O0�1�^߂yX���H䑾=��d�EI ޯ�`vuhq5�h��l0~��^gĄ��B���"_�*dk�jYh��!!+}�`	u,��WJ&	e���$��w@-������<g�凴a��f=@аH7D�@b��Y_/��qâ�"�C� �2tkH�ǌ��^ͻj���'M���B�̽L)I�q3�'믘�$�-�WYK���HcS�X�H%�!\�Y�W���Ŭ]�ؤ.�P��o��� �|���.����~�<@wɄM6P7(��8�I'
+�m`|^nV/�N*~�%qp��}�����<n���7^Cj�z��+-֒��cm�7K��Z��7l0����Q�
 ���v�������2���g�/���A�
������̶�<���4l�J�kI�Y���(�<CDы�,���t�v�l����.7�" r�B{�"�1XL���A�[���Uvo�A��N�\QPj��P���������� B�;�Bm���I�RY�'`������6�_01ZE&����?jE��dk'���p���AJt�H��n�p����aBhj�Q��M(�'ʬω�����
���N�����T�B��g��)U=� }��G���ˆZߩ?���V\�C��"��(�zfO��d0����V��.��{t9J��9�\\�8��}�1�y;R`/�R���B�<mm�X1b�maIl��͐v���ؙ`B��Xq�G�E�%�(bW�9g��\L���s��]��Ë��L�96���MX�i�Y��Ķ�4���̫&���'��Ug��^�~�8⏱����˂RR7,���H����vXM���7�O-D������js�dH�?��S�1eo��q�o��*�fPR��'H�G��o��:Lo���yS�NJ/vmku]n�����J��1*8����W��$&u��{%��f���j���7�tz*v�X���A��d����~�
~όa@����ׇ�_�$�V��_B��$xڐW�\�?x��]����]�
4+[|����	���鿢�m����=4�D�︶�N��xŴ�����,�Q.�ն��/��j"r��N��u|��������2��>��L� �_��]:U��:c���ں~��P�H���D���e�z��������F���h|�N q���"��!f�� 5D%�th�z��;)؞�*b:&
�_h$�^zNC�~�1�ԥ]��ia��������f'��I/X�?�ɼ�]B�����֜��Q�<���p���̵PȦ-R`�EL����
=׶kB��l}�z���`��d��@�F[�Ej�%:��+�ʫ�qP4�7�>m���Lq�j̋��.�It��
Q4�_;�~̶�RE�Cإ���Jڂ2\&�����T�jE��Հ6t֖q���OF��NT��Z�M� �x���7�Qj�<u��|�X�]<������t>)��Z�?��������0�,
.������ֿ�#ps�*.����M�L�3�
jc�ig�	��i��FT��n-k@�vw�Q�館I�>�I!}�vb�g��[^�	����YiR4�0]�ʚ�ݩ���껆�f�%�8�5�F��~!>�FTc�	'E�E~���oR�6(�����F��4
�����x��?pNI �ė&^/	��^Ň7L˼ާX�^����2��f��K�3W��u�\啔`�[p|j�����5������%���"�h�E����F�=.gU�hΧ�����Q�!�")����Q��A��G�N�?��~��ܹ����zvZ�izN��ЂE��πW��E:��X�cO
�S��(�9�Bb�p��8\x�;��������=�AN��W۶��D@xF'��i>��{g��H�{u������T{q��L����5F(��;ڻu������      �      x������ � �      d   W  x��V;�[E���bzv�����)�H�fw�V�wC⍔QR��@(��
�"����p���?�k{���J�w�9�w�9��-�\P#8�J0A�7�
�U�<9f�(�蹒�9F�`JC0��b���\E !7���P���fG��sN�ߜ��"�����|:��m����^�1�ʆS�D�wIӐ�ά� ��ߌ9E�l��M�=�X��)mVI`����0G>#c��sk��/^QQJ�/��2r*�qI9K�*�;�]�9�]N.�+���t+x#�>D��q�2���{�u�GLw6����	tcA=� b��D���t��J�Fp��[��H�Xo�u�Bwc��t����+T$�bYS�p�ɘ�"wF�d�9q�h�ל,� >H�f\�N��rJ�V�F�ᦹ��%�4�V���z�U�̢�V蔨a�U� o-�l���Da�dfט\4�k�ٞ�0��3-�.1���:�\Lc�� S��d*f6�pt]&�ޠ����,��Րc�)a�^����L���k�v$s-����Z��L:;��5��U<�MY��j���oǬb�/�φ�y0;r�@ԶeR�'�
Bxc=�,Y��<z4�d�3�[�G�9��6̣�FV(�T
���_�	�-�-��0�׿�su.U�����7�u01�B��3-GCD��ļ�V�V9Kw�q����T9������q�f3Mɘ޺P�]C�÷�ĝD'�/]��v�����
�xc�w�j����fԡ�UUkP��x�54\�FCw!ަ2Qn�Y�9L�l@moڒ7ۀ�0Ɔ�����YX����h9����[+[qT�2������FIs�fwm�Α�Y�,&��X�\a�`T2���!�=/�XL騢0O���=�Y;k+�v��VwΗ�oy��?�OHZ�_rg�xK>/~<#����r~�HOy����Hr2	��-g}{��d�'����r����	����������1�H?�Ç�?ɧ�����<	�0X��&.�_����,��)�q9�eZ�!��ђ{�+�S@UddWC������)��}yJ�'�7����xu:�OA��ix��q�v	�G�#䲡=]�"��rJ��� ˋ�=����︊��?9ƃ����_$QW�A��Loz����b�fo�d|����tL�������j���9iȽ�.;��d}�c��?�����.;O ���[����0��쒤Uu��׏٫g$N�����rwv(��!��A�'P���9\Vq��@���﷐��������m\+Dcc[��(�ɂj��
զ�o����(�������^ϛ��e�ռ.Q�0�f�YX����� %��      e   T  x����nW�k�)�fq���m �+�j��YHL#�$O�׈�t��Ҁ�Co�Y��d�"�=����g�:�"ڨ�x�PBH@Ie��C���z��0_��c	��AA��XʈyC���q!Y<�)�\ܼ��aw=�Rn�벳�$�q�w��3Kd���c{�[g_��j�@� v�G�\�+9��� 6H⦊f�`/� �J	�%���N���&�	��yq4'�u�����p=�.��H���(�MMZK���@д�fp�2|�Z�����v��0���ẟ1��r�\c�N;ט�V$u)� �J��rp:�ohs�f��@O3��k��� ���#4�'!쀵���]�z@����7Ŵ��}�������ӻ��O����n�(�Y�yNA؟EYT�������-ʌ���)��_Ê�Яc1���d��mݻ_?~��~~w���3T�Gh�,���#Xt�v|��Pd�!z��e���2�O�`�N~����/�|�;����,�d��"'��P<j�1��b_}VV[<-P0[\�H��3�nrv��~똟������$'�i1!�9Yr>���T��Z`eX5������q�k��+�Q�/�Ym?{H%�n�9}��&g���e��϶l�ߓ9�3�}v� /gʙ���-���ރS� eH���r%����ȍhM�K�l[2����a�����Wn���ԣ��̈˾b�l��"�SM�����zB�܂u��_�!k��[V9'i#w�Dtu}#��dO��a�d�VSi�F�7�� ���xYĭ�%�/$�T���S�
_�riݸ�kJQ{�$ߕ|����l�����������^��I      }      x������ � �      ~      x������ � �      |      x������ � �      f   �  x�Ŗ�nA���S�ܒY���%�A"�(���ى-�J�H�B(Ԉ�D)�!tv�(�o�1RGh�H.,�w����9+=��D�	���-6�b�9�}p��2�=y�^�����W��}��|T��f�Ҿ��ڭ��*����z�r��q3y�|3>~�����6�Q���騗P��L^�h�׌����1����*-͉L�;Dg���OK�$*�<��),��pt�}�%��*Y��t���}�q7�k���0���� v�_��/th��U�J貞?����c\�6�=��j4�`�������BTT����[Z`\�4�Ƃ���s쭐�Y�����#������O��dcZp^p�+��4s�E�����Q�EYE�*I���
��0VdjA���g�r~�L����>��>��-�埚��<.���@�ou��MH�D�`ЉB҂��q����d�@��g�@�l�M�s�b�^Ҍ/(�6=B��7��i�u7�KS;#���!��6��2~Ŋ���J����� ��H���赍���`��qa����{Q]0p��%l�L��+�P&`�8�1��u�Xb|Ʈ���H����*]R(fc�������#���O~���۱�a>�lB����a'����15�È,!pR'�*���2�H8}�,��@�~�?�8�G���-�y�d]҅#bff�(b�7�ͼ�j� ����      g   �  x��ԻnA�z�ۣY���܁(��(�̕X�V
'%��#��Dy�	�c{C@+�Xk�9��S"gSmUU*aF�CU�e���h�ޝ�y��6�_�������Y�����s{�zzu9�/Vˋԫ�����������u�!��v�/;"����h&2���;zv����@�P�m��<�λEW[�Q6���m��h��հP�n��b��2]�>5�������?�^}��;�N�`��ӆ0V���9�i�@�邊1h%9kF�ĸ`\�:����o�� N����(p���!@�\���-�$W�C4*I��9��I'g�w3]���d�M�a�>���� �����f�*j�-���V��W+�P=������'��Q�N͚�^�P��s������JP�zl]ˇX�N¬���8[�� Kd@�n{��jvTd��P�*E����\�"$�֔Tݵ뀫�h�`5�1�n��J�6@��8G�EfI�Ql~���P'���7!�Y�/vE4<���*�%vע��o���nAp���6ʛ�TD��}���ԛm|�
l�ԃnT�ǰ�Rb-!�c	bB&U [z����o��)B4�[���CX�Ck��z۲ÈmO��������'�m�      h     x����N�0�g�)�(vҿV*u�j*SP[�100uf*!�0%�+��o�oZ�q'Hm��9��ϹvI�������_��G�= �"��^'y�HYh��Dt�Vw����-�@"zs��i���|�������,n>ᣊhKD���P���*b��xQM����������SRDLWVp�?�-��>�J	��&D�2��eESB�R�O��ͳ������9���oD�kDCEod�)�(l7���������o�|ƒJ��P��'��g8-�䘟�S��r��Y;VQN�Xn����t�mBIrlx"|�8.nG��K�ET����|1��LDt��l�i��*��ڔ2���]-����������?��/�Ųq�DT��^RH��&���@Z\�
ۊ�Ɔ�д�~<��D�6�9�S�򜑓�yz.��~u�2%E���UXf����a��Ԙ_�܄9 [�_Y_���4*f���Q��*�4���&���- �-�Bn��I�+F��۪�j�%      i   V  x����m�A�����h��e�@	�82Ԕ+p�ԕ�S������of8��ڗ�Š��l!Ci���]��ɾA��Ѐ�>s�R^�]����6V�"h���!�WƑ�m�etx�!��ہ�:�4�$�8J���o��3���_?^�t`:ƍ���L��{6����s,��������p9L����HБ�ۘ�/�c�gz���*֣�C�r�V����OF��#ОF�*նnξ�j�Ѥ�g��v��u�Ð�V[�z�K�/��p�:���9l����%:_,<��w�I��a�ƀF���BÞS'��<��|��n_��      j     x���n�0���S����;΍�	v��D '��z�X%�XY*�)�c�H�ڍ���;���I\���X���~��`@H2��)�LQ�<�1b���{ɳ4y�{ݣ�R��B #D�}�h��#"{O�/����a<�����h�������L2`��)O0���@�����u�@"
_2B�5w��� %RyTg���E�Xc��k��	Q:v8Tꭡ�"������{�.x��>K��I�y�B&N9H�3Ȥ�=���y_!{07�c[�fqm����Җ92�U3;��e3+���Ӊ-*s�ms5F�^ٓy3��e�l>��ʖC�|8ww�YT�m�Lg�U]�j�����
5y�����ur����ss���^��'䣿 [�#��t ?��fZ��T��q���������؃����07�fXwLn7�A+���o��Z��Ũ�(]�-�Y,�|e������u���v	p��Q~ ���)"�|�	y����|��~Vs��      �      x������ � �      {      x������ � �            x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      �      x������ � �      k   q  x��X[o�~���O6�!vfo3,
�p4@����'���$%�Zt��q��#[t%٦.��H��ʗT��A�#�l���g�d�XTҗ��%��g��sff�C��l���c�b6���o1�L��Y�[�#A9!�O~�2�P}y���F4A=݉DF~S�RL�+EX�ԓ&�M�~��Ҡ��
!�r.\�)��>v�8�,�̶�.y"�w�r ���\9G{i4t�?���n��~џF��9��N�Hr�Mj��w�C���9�L	¢Xh�	8e��6�������;|��E���`�\8�S�'9ә���֘!�
�\[`�;&v�˰g�6u� ��C�����}2ix+?+��8|�q�M����>��be�0��q6<Y	�hT>����8|xz�M���HE'k{q8����w4 q�Q�-�s�8<��Q0;����l��w�(�7��K��3��K�uu�Z�ڗN#`�����{pq�W8��%N�0q8���O�v�u5���ۢ�BP坝��F��LBn3��Ĺ�8��^J3��ǣǧ� �8\��q5}��:Y�D�:/�����V3W�F��R�Q�H"��F�V2`آ��r�'L�T\� ^.��r �dy�A�*�9�;�M����|��I�χ��"9�^��g�f�d�f��z�㙻�rr޶*�����J ����jygD��qu1�R}�N:�=� ���y71�`ǥ�$�*ZEo������l�A@��V&/�r��t�����v�qNmz��}���8v�����fF 0s,Cs=�:��<tH�v����������nu����9T�6����,z��uut���Umv
U7w��Ok����Lmr՞��f��[�_P��[�ܬ��k%T����f�>�60����ԋ�
�4S���=z��]T����f�9�S�`�]���Y]�R�����,�$:GPrO���������L��\����uuj���i�ԢRu�:?S�.[ϗ'�"�fsE�;J���ʰ�1yx-yV_��O�VK�����e./sy��_4��$��HQ3I�M��gr��l�j�pL;Գ0��;�o�$h��4!~B~�)�LZ�iQ�]w��f �A =�A������Y,0YK����/�~4�/b��p>���6�^L� �`h6o�����������A�Z�h��LxM2�Oj�T.T����̤�ۄ�����0@��}�a�*�55��.��M��	m��0U1��D-A�t��_r���T{�����5����N!L��� !��0���0	$�7OK.4qϥD1@�Qi҂B�K��~xڏzҙ�2�b ����O�?݅>�V�N���՛w�2��x�_��ke�[��h�w�������Lg���_[6���	�\����G��Fw��jyB�ڝw5ѻ����3�%`^��u� ]7�����9ɏ��ݻ�Z��XW�sW������-u. O�FҦ�i��I�nP�b�6�07����f������� Z���W�d�pO����t�����N�)�BWg1��<��"L��Î��Y&�r���`���6���������?������\�wA?JY�j[�m�TsM�1��'�I�uj9������y��n��\;�����@�:ޟ�L��������ӵ���y��'O�@�W�6\Y����nnG[O���RmA6�.�R�,�N�.a��u	�}�8]��_(��j &������/�x�//����[S�e�sЄe�h��M,<,o��P�L ��t%S|Z-�l��X�^F�̄����3�i����2�˘/c����h�i�XI�KM�&c)�|�80(�v�Q�8D��2��n�Y���e��!����@RԵL����4488$A��ǔ����X����+W�~x�b      l   n  x���I�9Cיw�C�D�.�!5�������`� �Tck��Nc�$�(�.Zk��kⱟ���>���F�ƥ��i���ڥٟ��p�����'I;����T:�qu�]�#ٟה�hk�G��K�B��8��1�?5n�J���+4+�*��q/�����pqLS:4�����X��3��|qJ���eP;I+�h��G �Ҟ�[sf����O1�
�e�g��]�����SUԂ��Qnuǝ�m:?h���s{c:M�B�i&6��#�!��.�s	�e8S5�quS��m�����vg$m__p����_[�vy��.g�Q׏�!4J{���*�H���!�ɬ�7��q�3Ahm��5���<�iN��v���՞������1���f|��qY0p�N�&:}�s��b:��řH���yX�U?�} � A���?�o�N�uʻ�ܫ?ϡ�@i�\�%��6�`U��A�^�p� x��F&�E7�m���&��˂�>���M��F�[��?��8�{Ltı1��4M��qE�-w��T�bG�P3��T�}��`FV��h<�ruO�-�B�u������y2��yRf�s$U%�����p0����@�-����z��_Y^0a      m      x��[�oǑ��d� Q��}$w���heN搗Ւ�H��� >B`��3�p8%	�ql߃I������\U�t�T����ꏪ����|/N��Q�f��ߗ��Xܜ�������:;��l����d񺜰g��[�^��������\�3����tuw3�l��Φ��ugW��|��d�V�/�ί��O<�\��G�Y}��t�m~������ޟ7������ǶFly��k9B��0����Os��|wE�T�zG�ltJ!��X�x��}�.Nwc6��8����d%��G����`���
Wt���dW�n�q��_<����w芝��~j��3�]|�v
zݞ'��7W��rў��|2��>�/ޔ$�H�V��壡�t�K��A�c��5������}�k�E'u�c��[� �G����ј^��丿'��oKLI��qr��s%��M:��t�<w�L�߭��gB\��b��Y���z);�=
��$����ޠ/�����c�����7S+��G_m7Ǿ�d�Ơ�%���I�����<Gh���w�������c�Zdke.g���ڟ�N�� �\��O���̊����	/���tƨ�v�)�i#�@���|���R��{�l�?�������J����[�Jq��.�h�ޔ\�@�=l�0o)@�|������5��?tㇾ�{l�=�S�w36�3Q��ݟ�VÑ��ť[֔���\�����*��"ͻ��V9����6�LG����or�O�=Ԡ�x�ގ��4��'�Ҟ�U��(�(�(���6�����P�l��t(D��J� ���+�t�~ޗ�K��ڡ<�!Jz|��^�i�"��� i�a(K�����ΪY��_>!V�A6�������H��g���)mr��>����Mf�'�N������x*��U�g$��K���:�`2%���v�����p���g��!���dT��ހKn�����+ja����#z�4��'��[F
o�5�(jBɵ���m�g�e�t��A~ [L��s��n��P����f��~��-I�tq3Ep�!r���3$�����_�K�@��+�%X�u�<�s��t� n�~�s�E�i�g��;v��G5������v\��LA�7!��!:��u*��s��M���'@�-�j/πy6H0���W44�3>}��^[	��<_܂<��}>|��w�];� t��K~A�e�@��h!�A�;j����8p�^�E�E��ϯ���%{+�h�}$�|���#b�"G�>M�|׊� d�p�q&_����l�l��CG�Ov�Ih�ۄ��Ӈ��~��3+��oM�Tj8�#vYH�Y��&I�<�A�$��AnY��ѭ�0&��Z�v$�-�i��5!��Anŕ�bB�Bp��<�I�=-���7��.[�����ߏlQ����1�!~n
E{A�vW�?����T$5Eȃ����D�BM$#��X;���X.�m��VT$lg
�-�c��ܭ	R�����͸}��&��{`u���l�$��L�`���m�Y�:������P�s��ֆu����0���� �"��4����#����\r'�$pZ�C�7�E7ۅ�}�[A`�����B�c���ۉCI�^�{�;HG2;��YQ>x�!�\��1QJ%'��Fs��xni\[��	^ ���bV�59�3��?���඼6ÕlP�״s�#�3*^~�Y�G��H؝���)�ŷs���`�%j�a��<��T�P?9���ks���nI������O0��G�#��d4���^�|n%�M�Y�mBc8�K�i0�R����Rŀ��ǻ]s�p�Y��qw��u����N�rFh�����K�AC�S�GD���mk���mpO�`�S���a���v9-�.�b��`�0���#S�������8Oy~�qn?R�~Ġ�T��N>��?��o0�U���0���Nwǆ�R����xl/�������];fs������s=Flһ}��@6��@M2�$�����I���|k��Y�~L�p�������'�	�/�X��Z�7�}�<p���SܡN$H���K�=8�!�1�Z��(?�u�O�俌�K8��:��n���3�U��)������h9��v9����{��$#q���F4dZ> ܝ��a���m�Q���r�⒜aZ�>h�l���!�QO��ȫu�:-F�憵e��-*���b��4h�f�o�k�"���,��m�+��\̏�h�5�K�|���tL-si�� kn�$�X�"[����0�q݌59�uW����چLDB���*!���R2�~�zI�(�
��ʪ����˙q +�p[��\������s�=:<EZ1Dw+�������EW[��ُR��$QN3�9`�	���Z �U�G�z��f1$ID͌$��&�<$٩k|�Ƣܬ�Lm�Z%��4b�Ak�.9���}����,ޜ�KeC)B�6)B�%D���H��Bzyw`���
ԼX�vym)���8X9f�;"�o�yΣ���SL�=:m��WfO~m��������bnC&��4؄0�	!D�k�'ʎk�����L�
�x�%c�G�yi����e�`8�n�sH�P�<�T1'�D+Ewsw��n��M���פĜЍ�;�Y�Y���_�\�XA�/N��a������&���gEڲOI˗���ɏ�Y>��A���C������H�Hv��GB�������"�OoM T���;��_��!�;�x ��2k�H�B~��=�'&	!ؽ7�	xbsv0��ڥ��B:<�ieC��G�c�-��.��k�D'���b���CB4��Dk����ḏ|����Q���M��u��YW(�5���ז(��:SO�K��vLd���֎��͎��l?'���m2S������n�����y+|���H�o�+�?��eL���X�{��0��NFg#ʍe[��|��ǻ6�'"zvx�����8ۓ��'���7���Rl�9���������9��U���֐�ʡ{p��PY9ހR�l-Z��I�@�(�<�0���:[��IM�ʏ��5t\�@�d���Q�a�S�Ҩ�h.�a<M�7�}9��\�_kb��s3V6Z��q��j۲^�c6x��SV��[�p�"�
�\(&(l�-�SQ]V
��l�;���Pゾ�]�	)§!v�@#��S�>�}=��r�$6����	�����U�$���-����� �43�hʡ�N��:}Uމ�)0��hm�@W U�HA�$�A2��'��N`d-��t�f|C҄ �a���Ni��lȅ��IEhK.8	D�c#����ט6+Q�
�;z��Qn���������*S%n1Kr"�^Ѹ���
��i��)eO��6R ��tT1�;-gG%'���*���.��ҎS����hJT��,��٠�a��	E������+��	������l0(��$0�.��pr�<=j��rsǺ2s�M��¾�٧�����$6�C��3q�/;��uD�C{i�w��wJ"����9�ᐰ_dǼK'ſYG����
W	��V�i���Ӡ$./�ȡ�!UL�I���W�pI����} C�P���K{d?2��,H����N��dQ\�!��XL�ő$y���3b�j��'�k$���h�^��E�������~ŷ�� ���uecIs#<}E��x��PC](���7y�U7�6zdZ����2=�ϖ��$ԑ�bS%�
��.�ɍsP�귳ho(;�7Q�#�J�sU�c%Ӿ�Px������_! ����^b��X��Wv�l���/�Zs����������u+h�R}���{d-C�+>�8�[�O�IVZi���2#Q\�2Zm����G�@��%��4��:��=��MlU�7lm�`m��%�1XW�ލc���Z"6Ա��BBc,�kP�iE��J}k��S�^b�O'�u {  �R�#x�XJ�?�i�Jj�Xk�OhF�U��
e�Ӹi\i��x�i�����>���VS��vt}Be����(�գS�`T�؏��o<Iw������&�Ok����K��%������Ʃ.^l�ms�p���lou�G�>�����Óp��X~E��⇱ʥ���珴��7�����"��c��֓+(��ʺ������	he�m��W��r�!����6|��j���������}�o�	4�SXu1�S�U�8��Й��ƯZi�#t�Rl���k����ݣé��^��F��~�W`k>@4!���ơ�[��a���.N�fEy����:���!�F��M��ow�����C=*].�b�Xd��-748�|m�$4N�i2�M �y	�Ǣh��+�Q��#�-��p���0�h�D�a�x�~ �%ǱH�c��_�W���������+�	1�O��"�<���M��DI�i�iYM��܌��"������dU��@d[3�-[f�e�8�4w���A�pM�.�kBT^}�	U�q��3^������+-@��+���:b-TMe$�-�M��q�:�j�V5��_:B�t3�ͻ������(�&H�5��Ď���bOo�N����'�|��j��i      n   +  x�����0��v/d��K.BH���A�͞���8��Y0Yx�	k�̔+����Y��J���`���{�[|C�5�}\�69��ū�3W� h&�.R��=�vT{e�i�[�1�d�uۢ���cґz����<��.|��Rxmѐ���T���Ex�k�$�xh��%��	��"��=q���ɘO�.�O����a�������}�k��4P�iF�]�Ǆ�V�sI�shQ �c�|�8����CO�QRJa�i�jy��fN�E���$���c�.�ß�}���܁k�|��� n[߂��l�b1���6��U�K�zw=��L۬�rRX�Z��T{�kd���tT�x�ܑ`l�������l4����y�E��LZ����Vr��
U�����\�6�O�1�"�*���o�,�%0�������#��|�����N�E\��i�bS�����yV�k�I���LL� ��{n�hN}��z���r#XpUG�l+fOL��NIj_W���Q2N^��=8ˍ�ft|��+��VN#�Tz��y��q8,�      o   �  x�����,7D��傏� A��$��Cp������s����G�� �$b�bo��b�,>wˏD签�p2������R�ϩ�l���߿u2cڤ
�$+�V�F����x[�O�M:��Br�hY$���޴���|�n�䌠��I��凜c�u���~Β1��AR6(�7�*�j^ �ڃ��r�\!��fdcl?y��k��r�LmJb*��F�]�۬N�~���H~��7��Q�	 �E�A�U"|���ٺ�nm*�ɵ)�']eM�����{�b�Y�+@��g(�Z����.���GU�0�̓�:Evc��y���˦�����&坨�fŢ���=zW�kd� ���z���ݙ��R5�@�h��U�F���h�\$��ʶ��d�-�z]e�O/%'F�&�����1Ҽ�sQ��¥?H���K�{��&�FV�/MX�}/?­��އ�<�T�����-�l��k���B֐yx��YX�d�����o{i���m�)ꆅ�bj�e�t[�5r~��,��aE�I��࠽
}��:�[��x��F��,�	$Q3���X�6��{�76x�ꝩV�_����A6؏�����<��H�hXꑛ>�鹐"�{"�弟x�� o�t�"�{"��A�kR�D�G��k����=q��e�[)x���vYˎ�Er�'6�FG�m^BP(��7\��(�S�P�[����2�(�A�#ܾY��`-�ّ�%c�Cg܅�1 4�%����R�O/��xV�9�M��u��@o��FU]/9pDG�֞���s(�?�H��6���0f��r�8�HR�&��'��pκA�h���ͧ�\n{���=�渙޽���l����VF �d���Ǘ�$�C��*oN���q����9�g!�N��R|������ג]8 :u�E���ro|*���s�}�I��e����ۉMT�3>ќ.B�#9��*�
MC�5�}��z+'�\st����,�`>��k��;��_����_��      p   >  x��m�G��ޯXY*J�ƞ���=�!�CAJRHR�P�����n|��׹�O�]D�J")�ȩ�R�F��h�P���8m���}��Ů5R^�����33����y�����)$h&Th�!�Q$�?>
݇#������_u_�n}X��Tv�V/�zg�ᯪ�T<C�D$� ���a�b((t,��-$�ٓ^�yG��j��c���G<D8�$"}�0X�P䡃�<�9{rAZ�9�	�v��s	S*�"�Gt0陊5���'�9�����ojզǡ �b
��
�)��ʱ�cG�N�_������O�z��m[m�'�VN��?��eA���ԫ?��9z|�?�i6kU���^1��;-�VT��rn�FU�+vU���j˹J�4�a��������$m�ZX˘�����^�i���Q�u#á�0��4�,�8�$OX@�o: 182�B� !��,`�4�@	��<T���戩'+;�Vל����R�ݾ�T	E�nF��L;�C���9E�T�aa��!�1�r�ְ��y"��=�\*��B����Z��"�온`��}s�z��Hf�r��� ���d�-Xp@,����[A�Sc0#�V��Ȯ6�)�������f3������?O���߼��/~|���i�΃��6�^�����?M������^�^K��M��O��v�om��߻r=�vo?���t������n����[{���ǫ��{w��}�׬}�R��>�5r'��$ݸ�n�N7�H�o����2i���ݻs/]�u��>����{�߽:������n�����q�ʕ�|��_����;�!@����h>��E�9;�4Kߨ�vs�Xh�I�T�UK�vS��!�X�˹�QO@��sbԼ��{��4j�V�*�C/
�(��%�̹r�ѩG`�S��wv�|1����|IuD|an�XƳ@�H�����Q�UfNs�,"yV�p��no��R���NZ�z����S�!�O�Rg�싅N�Q��.;��As�v��� U��롱�Ķ�v,x��~�h~~h��;�7�t8�o��?ok�v�p��W|e�>���ʿ��^ ���IkU�΍_ֻ�m���Vk��i�{y{@�B�x��Lc�y<�J��Yg*��{�Ft�=Z�J�Xp���'�F/�&T�	Z���,�g��������d\1+Bn�ɓ&,�q���ȯ�$�4/�dZ<��<C�I�4	�-����X %1�!��<F�H����?^�W�c_��r�^��N|�i#̸&6 Lp ���eB	j�RRx5�g�����������7����i!d���%���	��� �(r�"�� s� "� �9�\X�1���_��������{��{>��������\**�Ҳ�r.�Yx9W>���+��.ӈ촍.��l�\r!���69e�q�r:iU��C�aW���؝�խy"p�G����߁��#*�ί\����CC���y�#9�b��K��m��J�t9W����E�Rg��>�����Æ����~�_�B�h8�ѷ n���(h�R���<sPDP�ٞ5���m�@ J�V ��*皬���5�S�k�=�0�R �������1cH"Q�����Ge{մL���_�OE_�A�gr�F���I4C�H2��s~(���f�6c����l�NO�	P��)�pRB�$�a݊*�cY�C�F�ѱ�bDQ�}O�׫�y���Sq�!�y��i<%(D0O� ��@3K ��S	H �CC�\:g���NF*�}��Q��E2-\����e��=~������� �      q   b  x�����9E��\��H"����x�-�ψ��K
r�|���p-��]E��B�B�+�	�*�	�ccD-��0��۱'�`R�W�)tG���c�@�!��rI���^~�ƚ�L�1�ǿks�����>bt��_�zݹ���y�~`=�9w鄩�.>qB��Ӵ,����ݤdٓ��K�l�[k��C��BLx�E`i	rM�v�wl��N�B��}IcA��V̋�P8��J���A}Ĵ&�.�SS�V���>Z�����^��A:���_z7h�d&�C�uj�B�>��W��m��Y'��F3Y�9�!h,����ǌ�Ą��+���3;��m���\��۹m� ���`νΘjᲹ֓���kî�Lj<��U��XnO����L�݁o9�l�޼�П�ц�ݶpu���r��G�1/�����!=_��zf7Q@F��׶?�D��;���2̡T�1[��ެ�Nn*�/�����G�f	-�'6�X�id6xt�Lg��Va���|/�����Q��E`K���֝��m�1mI�u?���D�
��D�x��oL8x��	��r��&	B���]�V��K
�#ٟ-�rOB�'�=�������}���z�      r     x��U�j�@=��b~��VҮ�k|h�r0�B.�B�"�&Ĳ���C��Pz�UK-��T/9���dd)T�F6�7o�y#"X���Ι�z�C�2vtP�u��Pٿ�w�3�F���`q��uB�{�"��c���N��s=b�XT^��.f���d�e{6O`��I���oZA������e-��(�]�4��hD�*�H�<�u�3��9�>Q��̗t���ՙZv�vO�X=y��8�!��(ř�.����ŵ\o5\(���Rl�9A�0u��c)��vOuE&}�	kv"�jP���R<E�4�9Rb��$�g~��tt�*%�j"�5�)��
��M�����N�=<C�3?ൽ�xe���ы3���MŒ��q�u�h�DG�j.�UCX�~�y��	��N���/ת	�����3�pq&n>��7M k0kOKԢ� q���:�~>��q����Ó;�$`/��I�xĽz��$=���9�ya��gR�ai�s��&���M�Pk�*ʈ���G;�N�_C4�      s   �  x�픻�1���S�ydߧCZ!**��6�Ύ�:�M"ҬD��/��D���$�&̬.!� �?��=�J���f�HY+2#,R�K��T]>��bՓ�|���a���j��Bv_^V��eW��q��J��0F� &���F-D�	�4 k�m�����ʑ���R��J9S"�[9^��H�LT�(�����n1�,`�Q��Z��^@���m7�>up�8Z`������6\�$x�쯀5���1�2�0�#��"��� ��G;~�8j�|���z�6	���V�6���W"��E�ҵ�+���-�����#���F�5�3���XN�iL�:�	S��=��=�%�l��=Q]C�����W����P�o�X#X-�UR����c1jn)*;�˅NF*�%�1M|��d�"q�b?:+���F�U�7���[��������8��6������wU�f����x      t   �  x���ٱ$����|��`^��&܏3�q��,��)�Qj<�k%����!Rt��Y��R��&?f)LM+�VR:��8i��Q���؎;�<��N�p�#J�[��K�.�ثN���}l���.�+�|��%QwPݛуyiᬳ��tV߿���5/yİW�Pd�`�[ر�>��N�Z�ncZ8R��x��������[��"y�6��C8�]���R��֬��=U�Ӄ�B���[[avӦѵ�F�s��)D�-��-t�=�:���7�^����������L��!k�3����|Ͱ}dzRE�p����!�o�-U�U����"d�F/�{K&��4g��Ëz�&e�����M�-֦Eںs�#�׏9Z�֚��+�m�kObD��1�[���<��[ƍ�V�^����H��0�6�|VM��F4i��WY�a�&T�V8݋ZMRb�+�:���6c�>B?��D�y�a^�:{��BG�*�[������._~�&�RO�*5�)���5d76�>�JqQj�#�{X3�I%xv�v���
Gr�k�Uk)��f�a���^�'����������J�g��=�����\۝j^�5_-�j�c�9���q��,�\�E}�V,�k!��kڌ�k�K.&�9u�X�RoHKlVғ8κ;��':{>��e�`ak:����[�vO߲EY�B[�pȭj	�=�\�ۼאd���#�T��3Y&�@&7�?y����.9a���W�S�����2��^T����?��Cc:w�4�[L�����;-���U�AW%�����G�^��#���9"�T����T�P��;V��*����K\k/fJ߿do�R��6eǕ�ѝP���1�vQ$���|R�_�i���F��p���Zu-�ͤ�����_�:G�-�?��V�[���򱤍��cr��� �|���)+B� �� 	��d�s�P	�Aa�1�¶.3M6���8�S�{����FN��9+fn��v���/=���e��p��/�s�%��?K;�]�}ܽ��8�l��0��7�Ȑ��)ZZ�M�������
��Q0��y���E�ƙf��q��@��'X������\w�zN*����y1CArR���\���F�	ʇgX��-�k��B�#�	�Xf�eC��&�� ���X��j�2�6`��,.@������Q;��2��S�0J��$󼆛����ZBce��[�wD[����+�� ����JQy�&�b�>䢦+�ETZ�ŴRNwd7���h���Q��0�YB��x+
0�ł��pE�Nh�����;	Lo�-�}WW)�%Q�B����� ����2FeQ^�y�C�P�AW��0�f𙄍E��K���fE�Ǹ�?<ޡ (�>(���=��-����(�2��ۈ'�݁�?1�<TXahšvy���� �Bh#�"\4z�Bo�6��z�Ub�J��-hzx	�fB�kRx>[FJ��?��A���J�ˌv3�k,2S������]z���#�P�wE��RN��E�������jϽ���/9n��X�2n���\a�X���,v��kMx��;\&,HL��=Gco�~:ގS����7c퐡��&\[Q��cz��=먺x3v c��g:ÜY��YP��^���k�u��8��cY����W$��������\3wm`{�q�^����Y�|���#gN�n�_G�1�&�	����׎��A̙�&"^��a'3ߒ�P�.�wZ�Q���p��I�K���	��'�g`�0Q�9���%Pj����a���h���մ���]jL�t 
w�8 dr�z�=��{.ՙ\�L�K�B��14W�oW���[ۢ7TNWD1I1аa�_+<�çM������p�0�sajW�6�1���|��u٥\��H��,\��ov(�fHˈjCO����yp��	���|�:>�5AZX�l�.I;�q�.X�6PŸ)�p|1g������)���?�S/Vƍ�eފ��_��Q�p	҉R@�3���"�.��*�z��7�%�S��.�V�ۺ��~�����%^�ոi��dsVdt��1�?�V�0��\��(������Ӑ-tz����8�x��
��:����3��҆��d�n \���b(���'�c)B:��"�Fa���~aP�dc�ݗ�e+x�+�qǥmB�ܯU�t�����ƁB;�"�b�,�n�l�{�d^��M~l�h��Ǐp`����T,�L�sb��ќVcAk�2M�����/�>V���~����1�      u   �  x��V�#9|{ra!$ ��!����&0�q�S���FNH�]J#�>hiv����vw�?��_ne���Fz�P���w��������Q��Ms�;/m��^�Y��i����E����݂g ��~�8�Φ��헼5�^�Ͳ�����l���F�D�ܕ�s?;+��:�%ӂo�5y�jԤ��9ô=k��:5�tm��kԦ?q��Jב~A/-�����,������o��2��q&�t�0�f�y�]�M��o�~L�U�@vyG��h3����u�n9nE�=��8�!N�W�������C;��N��5t�t[�u����[�ڸO�*Ƿ��#]*���O�6]��Y,d�F+�-��b�g�T*[�ڜ�2�I%C��;�����t�}���S6[$��l}$D��O�+dtm��y5cr�E��t��ڡ��kÂ�IA�Wi-r����e0�������ڀU��޾r/7u#A���)E���n�S��)��M^'�F���}�~!�=�W��ł
���O��pW�9S�ă�y�@�Ǩ�$Y9�0t�����}��hBS(����v����=j�xx�H{�oZ�\��W�pdӚ�<	��w߸�G�%m< k�C*�&2%?G�7xV[��O�̨�$q/vi��(H�;op�����J�۞� A�������v��>��U_L�7db�'�	��Z���5�؎���9
�[ W�M�P��~<��_p���*�����;�4�#�����z�*�f���A����a2p�&'��P
lqL�kt��3�JzA���Jy`L�"�����a����+��0�UƷw�[�b7�wP���v.�e���-�ΰ�����īi`��G��<6��?����]AY      v   {  x���M� �ם�0O�Q��l@��G�ʜ �~c�G��}o5�^����{M��#�����+�7�p!�2��^��k?���x�� ���j2��$InM��N{nt��W�$ͩ�փ��*��α�k��0w']�i�5��Z�:�7��Q>Ǣ+��1����_nG�ō7�O���9�1��"�� Y��,�ɽl��y!s�)��Z�\s����'��W����q���C�)�[�}#Ցa����rMA\]'�h�{�;Dy�_˒=��:[������j�YT��� ����&��w���f��CHF�j(]���]y�c�2���՛a%�sNx��l����)�>|rEyO��c�X�ضo����S���� �V	����H�ɯRθ��5Ry��Q����"6L�	�������y�R��^�z�+RIc�^�w�B�r
{��;��v�T���e�N�h�Ո�ռ!�g~u�'��}�1���Fq\�Z��-:���K?��4o�D�x�<QM���`W�@����]h�p1ܭ�����8�U����p#���b`��J��e��W��VT�4�a�5uS�T���H����T�9h�k��D�gPt�u��|@t[���zCߍb��i�o�x����$��<��dCU��CV�Z!5x`����K��0�FG��C�Y�m5��S�T��ϙ�� ���p����j��}�)�O�{�eB�_7 È�#@U45*�N�O�%�&iN{�:����]=�W�Ɔ���L`�;h���uce�a�Ln�����C�`%�hMt�����f�Z�&
���o�\}�SM�~<���w�tbW5l���Y������4��Y
�7��Vvj'yf���	0���9��$�����Xg�f�?1����<�?��UM      w   �  x���˱d1C�ݹ��6` ���1��0���[�I�]v7��[@�/�c��F�?�+o�YoD���ྭ*���~Gmq��n�z<�a�h��Z��RYb(�7(�AlA(����g徊���|D6�H��4��D��ZWv6ȶ�Z��7�Z�_�{_2�]��\��Xr�\�k�.R�Nd�E��Nf~�0��}�R��������V�X��T��|���#E�����S�^���@$�����O�q�%���R��B������L��\��u7^7�
��(󁉵����|^�E���{z��`�>��&緩P��������tj�3U��q��Ґf5�р|Oc�zz��w��
�2���x���/JV�d>���T�t���s�����z0W��
փ��~z����?S�x      x      x������ � �      y   G  x��V�NA��>�ޛivvfO�31�C���ZXZ"w�) �� �@[9��E�1�G3-��pf���4$�vv������Yi��{����	}`kf m��m?�D
���t��ޯv�k�Y�E��A����C�R��������7��A��T7������F��tFM���<@���k� ��B+a�	����<�,���)=ݭEL�i#'t\��N \l� ��
+�=�*�u�r�dXy���S_eG�H�fGT�}y[[q"͂���bt���Db��4:�D�؀HrU�|ږ�{��@M���7J�ɯ�
�z�\n����������#��`d��5����9F�12��ˑ�m��x�o�>#S�cǌ�)0J�JUF�%xK\i����4���FN����R�Qk��X^yȄ��|/<\`�r�s�[��;ܖ���x�%�b��տ
:�H��U	.���ղ���{d�'�<<<+V�����ό��˗X������o>�s�[��'#�����V�xʂ������h�h�]+Ri�}j��ӂ�S(�PhU[2��Î���$�|�p*����̓Y�ΰ�ܜd�H�}9^�Io�}����������T<��qR���i�HtmU��m�K�q����<��[�Ik8��E~�yX��9�v�dV.�e�/����'��[s�X���,���N��0R�:��+G-rB:����[�a��[��ab&t�@0� �莓.�l'z!�.D ��	#�f`Z�X��,~�ԫ��i��k%�]Uף�ߣ#�������	d$ �ChC�}����t�z�X�\�0�      z   '   x�320224040�4155����,�4�3г����� lXi     