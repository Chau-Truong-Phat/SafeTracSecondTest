PGDMP                     
    z            MedWorking_Staging    15.0    15.0 7    i           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            j           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            k           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            l           1262    24984    MedWorking_Staging    DATABASE     �   CREATE DATABASE "MedWorking_Staging" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'English_United States.1252';
 $   DROP DATABASE "MedWorking_Staging";
                postgres    false            �            1259    24985    Accounts    TABLE       CREATE TABLE public."Accounts" (
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
       public         heap    postgres    false            �            1259    24990    ApprovalLevel    TABLE       CREATE TABLE public."ApprovalLevel" (
    "ApprovalId" uuid NOT NULL,
    "ApprovalName" character varying(200),
    "Value" integer,
    "Description" character varying(500),
    "CreateDate" date,
    "Active" boolean,
    creator character varying(200)
);
 #   DROP TABLE public."ApprovalLevel";
       public         heap    postgres    false            �            1259    24995    ConfigColumn    TABLE       CREATE TABLE public."ConfigColumn" (
    "Id" uuid NOT NULL,
    "ViewType" integer NOT NULL,
    "InfoJson" text,
    "CreateDate" timestamp with time zone,
    "CreateUser" character varying(200),
    "UpdateUser" character varying(200),
    "UpdateDate" timestamp with time zone
);
 "   DROP TABLE public."ConfigColumn";
       public         heap    postgres    false            �            1259    25173    Decentralize    TABLE     L  CREATE TABLE public."Decentralize" (
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
       public         heap    postgres    false            �            1259    25005    GroupDocuments    TABLE     �  CREATE TABLE public."GroupDocuments" (
    "GroupDocId" uuid NOT NULL,
    "GroupDocCode" character varying(10),
    "GroupDocName" character varying(500),
    "DocType" integer,
    "AdvisoryUnit" character varying(50),
    "DocNode" character varying(500),
    "DocActive" boolean,
    "CreateUser" character varying(20),
    "CreateDate" timestamp without time zone,
    "UpdateUser" character varying(20),
    "UpdateDate" timestamp without time zone
);
 $   DROP TABLE public."GroupDocuments";
       public         heap    postgres    false            m           0    0 !   COLUMN "GroupDocuments"."DocType"    COMMENT     f   COMMENT ON COLUMN public."GroupDocuments"."DocType" IS '0: Thông báo/phát hành
1: Thực hiện';
          public          postgres    false    217            n           0    0 #   COLUMN "GroupDocuments"."DocActive"    COMMENT     [   COMMENT ON COLUMN public."GroupDocuments"."DocActive" IS 'trạng thái nhóm văn bản';
          public          postgres    false    217            �            1259    25010    Office    TABLE     I  CREATE TABLE public."Office" (
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
       public         heap    postgres    false            �            1259    25088    PatternDocOffice    TABLE     �   CREATE TABLE public."PatternDocOffice" (
    "Id" uuid NOT NULL,
    "PatternDocId" uuid,
    "OfficeId" bigint,
    "ParrentId" bigint
);
 &   DROP TABLE public."PatternDocOffice";
       public         heap    postgres    false            �            1259    25081    PatternDocument    TABLE     �  CREATE TABLE public."PatternDocument" (
    "PatternDocId" uuid NOT NULL,
    "PatternDocCode" character varying(10),
    "PatternDocName" character varying(500),
    "GroupDocId" uuid,
    "Description" character varying(500),
    "PatternDocActive" boolean,
    "TemplateDoc" text,
    "CreateUser" character varying(20),
    "CreateDate" timestamp without time zone,
    "UpdateUser" character varying(20),
    "UpdateDate" timestamp without time zone,
    "DocumentValue" character varying(250)
);
 %   DROP TABLE public."PatternDocument";
       public         heap    postgres    false            �            1259    25015    Position    TABLE     N  CREATE TABLE public."Position" (
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
       public         heap    postgres    false            �            1259    25020    Role    TABLE     V  CREATE TABLE public."Role" (
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
       public         heap    postgres    false            �            1259    25025    RoleDecentralize    TABLE     s   CREATE TABLE public."RoleDecentralize" (
    "Id" uuid NOT NULL,
    "DecentralizeId" bigint,
    "RoleId" uuid
);
 &   DROP TABLE public."RoleDecentralize";
       public         heap    postgres    false            �            1259    25028    UserId_Roles    TABLE     w   CREATE TABLE public."UserId_Roles" (
    "Id" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    "RoleId" uuid NOT NULL
);
 "   DROP TABLE public."UserId_Roles";
       public         heap    postgres    false            �            1259    25031 	   UserRoles    TABLE     �  CREATE TABLE public."UserRoles" (
    "UserId" uuid NOT NULL,
    "EmployeeCode" character varying(10),
    "EmployeeName" character varying(250),
    "OfficeId" bigint,
    "PositionId" bigint,
    "Description" character varying(500),
    "CreateDate" timestamp without time zone,
    "CreateUser" character varying(100),
    "UpdateDate" timestamp without time zone,
    "UpdateUser" character varying(100)
);
    DROP TABLE public."UserRoles";
       public         heap    postgres    false            �            1259    25036    __EFMigrationsHistory    TABLE     �   CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);
 +   DROP TABLE public."__EFMigrationsHistory";
       public         heap    postgres    false            �            1259    25146    viewaccountdetail    VIEW        CREATE VIEW public.viewaccountdetail AS
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
 $   DROP VIEW public.viewaccountdetail;
       public          postgres    false    214    214    214    214    219    219    218    218    214    214    214    214    214    214    214    214    214    214    214    214            �            1259    25039    viewgetdetailuserrole    VIEW       CREATE VIEW public.viewgetdetailuserrole AS
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
 (   DROP VIEW public.viewgetdetailuserrole;
       public          postgres    false    218    218    223    223    223    223    223    223    223    222    222    220    220    219    219            �            1259    25151    viewinfoaccountdetail    VIEW     `  CREATE VIEW public.viewinfoaccountdetail AS
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
 (   DROP VIEW public.viewinfoaccountdetail;
       public          postgres    false    214    214    218    214    219    214    214    218    219            �            1259    25130    viewsampledocument    VIEW     �  CREATE VIEW public.viewsampledocument AS
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
 %   DROP VIEW public.viewsampledocument;
       public          postgres    false    227    226    226    226    226    226    218    218    217    217    217    226    226    226    227            Y          0    24985    Accounts 
   TABLE DATA           7  COPY public."Accounts" ("UserId", "UserName", "PasswordHash", "EmployeeID", "Office", "Unit", "Position", "FullName", "Email", "SignatureUrl", "PhoneNumber", "Auto", "TimeLogin", "Online", "Level", "HC", "Active", "AvatarUrl", "SerialNumber", "CreateUser", "CreateDate", "UpdateUser", "UpdateDate") FROM stdin;
    public          postgres    false    214   gT       Z          0    24990    ApprovalLevel 
   TABLE DATA           �   COPY public."ApprovalLevel" ("ApprovalId", "ApprovalName", "Value", "Description", "CreateDate", "Active", creator) FROM stdin;
    public          postgres    false    215   _       [          0    24995    ConfigColumn 
   TABLE DATA           ~   COPY public."ConfigColumn" ("Id", "ViewType", "InfoJson", "CreateDate", "CreateUser", "UpdateUser", "UpdateDate") FROM stdin;
    public          postgres    false    216   _       f          0    25173    Decentralize 
   TABLE DATA           �   COPY public."Decentralize" ("Id", "Parent", "Name", "Description", "CreateUser", "CreateDate", "UpdateUser", "UpdateDate") FROM stdin;
    public          postgres    false    231   �`       \          0    25005    GroupDocuments 
   TABLE DATA           �   COPY public."GroupDocuments" ("GroupDocId", "GroupDocCode", "GroupDocName", "DocType", "AdvisoryUnit", "DocNode", "DocActive", "CreateUser", "CreateDate", "UpdateUser", "UpdateDate") FROM stdin;
    public          postgres    false    217   b       ]          0    25010    Office 
   TABLE DATA           �   COPY public."Office" ("Id", "OfficeName", "Parent", "Description", "CreateUser", "CreateDate", "UpdateUser", "UpdateDate") FROM stdin;
    public          postgres    false    218   �e       e          0    25088    PatternDocOffice 
   TABLE DATA           [   COPY public."PatternDocOffice" ("Id", "PatternDocId", "OfficeId", "ParrentId") FROM stdin;
    public          postgres    false    227   rx       d          0    25081    PatternDocument 
   TABLE DATA           �   COPY public."PatternDocument" ("PatternDocId", "PatternDocCode", "PatternDocName", "GroupDocId", "Description", "PatternDocActive", "TemplateDoc", "CreateUser", "CreateDate", "UpdateUser", "UpdateDate", "DocumentValue") FROM stdin;
    public          postgres    false    226   �z       ^          0    25015    Position 
   TABLE DATA           �   COPY public."Position" ("Id", "PositionName", "Active", "Description", "CreateUser", "CreateDate", "UpdateUser", "UpdateDate") FROM stdin;
    public          postgres    false    219   �}       _          0    25020    Role 
   TABLE DATA           �   COPY public."Role" ("Id", "RoleCode", "RoleName", "Description", "CreateUser", "CreateDate", "UpdateUser", "UpdateDate") FROM stdin;
    public          postgres    false    220   �       `          0    25025    RoleDecentralize 
   TABLE DATA           N   COPY public."RoleDecentralize" ("Id", "DecentralizeId", "RoleId") FROM stdin;
    public          postgres    false    221   �       a          0    25028    UserId_Roles 
   TABLE DATA           B   COPY public."UserId_Roles" ("Id", "UserId", "RoleId") FROM stdin;
    public          postgres    false    222   �       b          0    25031 	   UserRoles 
   TABLE DATA           �   COPY public."UserRoles" ("UserId", "EmployeeCode", "EmployeeName", "OfficeId", "PositionId", "Description", "CreateDate", "CreateUser", "UpdateDate", "UpdateUser") FROM stdin;
    public          postgres    false    223   ��       c          0    25036    __EFMigrationsHistory 
   TABLE DATA           R   COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
    public          postgres    false    224   f�       �           2606    25050    Accounts Accounts_pkey 
   CONSTRAINT     ^   ALTER TABLE ONLY public."Accounts"
    ADD CONSTRAINT "Accounts_pkey" PRIMARY KEY ("UserId");
 D   ALTER TABLE ONLY public."Accounts" DROP CONSTRAINT "Accounts_pkey";
       public            postgres    false    214            �           2606    25052     ApprovalLevel ApprovalLevel_pkey 
   CONSTRAINT     l   ALTER TABLE ONLY public."ApprovalLevel"
    ADD CONSTRAINT "ApprovalLevel_pkey" PRIMARY KEY ("ApprovalId");
 N   ALTER TABLE ONLY public."ApprovalLevel" DROP CONSTRAINT "ApprovalLevel_pkey";
       public            postgres    false    215            �           2606    25054    ConfigColumn ConfigColumn_pkey 
   CONSTRAINT     b   ALTER TABLE ONLY public."ConfigColumn"
    ADD CONSTRAINT "ConfigColumn_pkey" PRIMARY KEY ("Id");
 L   ALTER TABLE ONLY public."ConfigColumn" DROP CONSTRAINT "ConfigColumn_pkey";
       public            postgres    false    216            �           2606    25179    Decentralize Decentralize_PK 
   CONSTRAINT     `   ALTER TABLE ONLY public."Decentralize"
    ADD CONSTRAINT "Decentralize_PK" PRIMARY KEY ("Id");
 J   ALTER TABLE ONLY public."Decentralize" DROP CONSTRAINT "Decentralize_PK";
       public            postgres    false    231            �           2606    25058    GroupDocuments GroupDocId_pkey 
   CONSTRAINT     j   ALTER TABLE ONLY public."GroupDocuments"
    ADD CONSTRAINT "GroupDocId_pkey" PRIMARY KEY ("GroupDocId");
 L   ALTER TABLE ONLY public."GroupDocuments" DROP CONSTRAINT "GroupDocId_pkey";
       public            postgres    false    217            �           2606    25060    Office Office_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public."Office"
    ADD CONSTRAINT "Office_pkey" PRIMARY KEY ("Id");
 @   ALTER TABLE ONLY public."Office" DROP CONSTRAINT "Office_pkey";
       public            postgres    false    218            �           2606    25062 .   __EFMigrationsHistory PK___EFMigrationsHistory 
   CONSTRAINT     {   ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");
 \   ALTER TABLE ONLY public."__EFMigrationsHistory" DROP CONSTRAINT "PK___EFMigrationsHistory";
       public            postgres    false    224            �           2606    25092 &   PatternDocOffice PatternDocOffice_pkey 
   CONSTRAINT     j   ALTER TABLE ONLY public."PatternDocOffice"
    ADD CONSTRAINT "PatternDocOffice_pkey" PRIMARY KEY ("Id");
 T   ALTER TABLE ONLY public."PatternDocOffice" DROP CONSTRAINT "PatternDocOffice_pkey";
       public            postgres    false    227            �           2606    25087 $   PatternDocument PatternDocument_pkey 
   CONSTRAINT     r   ALTER TABLE ONLY public."PatternDocument"
    ADD CONSTRAINT "PatternDocument_pkey" PRIMARY KEY ("PatternDocId");
 R   ALTER TABLE ONLY public."PatternDocument" DROP CONSTRAINT "PatternDocument_pkey";
       public            postgres    false    226            �           2606    25064    Position Position_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public."Position"
    ADD CONSTRAINT "Position_pkey" PRIMARY KEY ("Id");
 D   ALTER TABLE ONLY public."Position" DROP CONSTRAINT "Position_pkey";
       public            postgres    false    219            �           2606    25066 &   RoleDecentralize RoleDecentralize_pkey 
   CONSTRAINT     j   ALTER TABLE ONLY public."RoleDecentralize"
    ADD CONSTRAINT "RoleDecentralize_pkey" PRIMARY KEY ("Id");
 T   ALTER TABLE ONLY public."RoleDecentralize" DROP CONSTRAINT "RoleDecentralize_pkey";
       public            postgres    false    221            �           2606    25068    Role Role_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public."Role"
    ADD CONSTRAINT "Role_pkey" PRIMARY KEY ("Id");
 <   ALTER TABLE ONLY public."Role" DROP CONSTRAINT "Role_pkey";
       public            postgres    false    220            �           2606    25070     UserId_Roles UserRole_Roles_pkey 
   CONSTRAINT     d   ALTER TABLE ONLY public."UserId_Roles"
    ADD CONSTRAINT "UserRole_Roles_pkey" PRIMARY KEY ("Id");
 N   ALTER TABLE ONLY public."UserId_Roles" DROP CONSTRAINT "UserRole_Roles_pkey";
       public            postgres    false    222            �           2606    25072    UserRoles UserRoles_pkey 
   CONSTRAINT     `   ALTER TABLE ONLY public."UserRoles"
    ADD CONSTRAINT "UserRoles_pkey" PRIMARY KEY ("UserId");
 F   ALTER TABLE ONLY public."UserRoles" DROP CONSTRAINT "UserRoles_pkey";
       public            postgres    false    223            �           1259    25073    fki_Fk_OfficeId    INDEX     O   CREATE INDEX "fki_Fk_OfficeId" ON public."UserRoles" USING btree ("OfficeId");
 %   DROP INDEX public."fki_Fk_OfficeId";
       public            postgres    false    223            �           1259    25074    fki_Fk_UserId_OfficeId    INDEX     V   CREATE INDEX "fki_Fk_UserId_OfficeId" ON public."UserRoles" USING btree ("OfficeId");
 ,   DROP INDEX public."fki_Fk_UserId_OfficeId";
       public            postgres    false    223            �           1259    25075    fki_Fk_UserId_PositionId    INDEX     Z   CREATE INDEX "fki_Fk_UserId_PositionId" ON public."UserRoles" USING btree ("PositionId");
 .   DROP INDEX public."fki_Fk_UserId_PositionId";
       public            postgres    false    223            Y   �
  x��[�n���f��/��燇d��x��Hb$�`��oZY[db�nu�(�(ػ^�7Yt�-���"��=�&��C�Jnw{3C�%��>ϙ����y?5z/ND��c#����Ş,2���G�������yS�!<�X�3����0P�������:<���:��oV_¥�������Y����f�gB��/~�qK�8<����-ʼ.{x*�gQ�u�T������Y?Wo��`s}W� Ԁ�Y�բlOZgBa��B��1Q�_6�ܬ����͌qp���@�`j�K4���@��?���Yق.ʼ�A�8C��D�+� ����
^^�j��&��v9�{�Y$�'3M8��|�����ۚ	^j�?��`ǌ�Z�x���L�2�wYM�6�'DD E��#��"<�6����ăPD��x���	��+g���o;�=^=gB&����dxJ�2Xӡ����f����.F� J������Kؙ0��dr�O�0�kHz����,�f)<�����mx8�ZW��Jp�aZ) aYM������ l���u��~� M�2��}��WTd��|E�g�~�挦�	�څ��:BkF�=n`J�W��9WH'�yU�>���֙�h�����爴�@��_���=q_�)z�9�W�s��l@:�h\�&��5�T$bͷ����1�I�2 '�<[�
3e�zSF�g��
Ky�	���:ŏA��.'�'��O)=�#�d��~�1��l���N�κ�C#L��-��%�^�ځD��S�_Q1Ov]����f_��P��v���'�Q�p�AL(�**�.�B���������w&�P�@�bjՠd�P6��O�+~�r�7�?�/s&|P~H��z6 �tCD�$�����H�,xV�s���c�n�����C8ܫy_��*<��P_:����)%�!nFy���)I��x������46U�ՉTr�u��p��Z�: q���M�������"_�G����K��{��p�#t��L�4`u�2�ď��t��2۶&��f�����g�Q��З@�9���G?��R��+6�}i��%+h��Y��Β?�a�������J�T )��[���唩=�?x})pE��rVxg���/f�%�QH��aSWR\K
���4@��"�^�d5}�#��dC]G���p�����Y��bW���Jl�֨b�{����uJ犂R�V����O����\���j3E�@j��2?� �F�\�������j(2y�7��*�H���N��7�>�/ƣ��\�:����aÄ��ڣ��PXO�ِmO��=�Z'N[��!��T�B��g��)U=�(}w�E�����Zߩ?���N\�C��"��(�{fO��t4����ր�.��{t9J��9)..NXr�!��)����p)���!r����	��	�خ�$���fH;��V�]�L0!�`�8r���"vݒI	��Μ3L� .�h��NԮ��L���{���@�&�մ�fib�d�`qa�U�b��I�}�p�W�_2��c,)8?�����MK��i�� 9cԎ��������ռ�^�[BmΙi"w�'} cj2��9>n�ͷ\ڌJ�_�i�Ȟ���B����09o��i�Ŏ�m����w"���^�8F��w����¤n~y���ێ�B��\����@�nr�0�ӽ, W\��OZ��q$H�c���X�K�d�
�a��s�OZ�J�o�k��]��B�fe���<8!Z�9�*�fT{�a�C�L���k{�$ʏWL��/�����Xm�����Y1�&"�xr�$�Q�7�H���p���-)��~6�������wKG���WϘ� C����-0T0��h���o;|٬^�6���qx9��"s"_u@����$�l�Y{<.HQ	Gx(Z��^&t�N
������I���g��&ɰ���PXv��7u閁��tZ��-8&�)��w��	.�AD���ϟj2o�a�|&�u����5�v�9�?�u�m��4s-�i��#D0��Fh��Aϵ��.[���^�c3����8i,��Vs��n�N�����G��M�O'xcS���"(�o�h�B���͠��C�TQ�v){4������	�!�@�F�'կ�Z`b5��Ā�e�&�%F���Qs�U;���`S&�)xQ����4�@�㙧��љ��ﰋ�v޽X)�H�E9BH֊�q_g����U��w�(�l��n��:[o�G��P]^be
��tg�6��6	��4@IӾ�I[�FT��n-k@��w�Q��lHƗ>�I!}�vb�g��[^�����YiR��8]�ʚ��ݫ�������f�W6�q0k჆}�B|�&HN��0�\�ŭ	��p��a?-|xe��锉&~�{ rA����u���»���xJ�&�4�z]��ؗ+?�aZ6��>�2��L)�-��k�ٻ(��se��c�`w��/=:^�Y��A`��+'4�V�X9��'|��sX�S��<oQ�z�]!RZW[��^U7���jV��|��y>�G:���x~1�KT�2 ?�^���������\��|睞�5����_?>�`���+��؋t�_���-�֩ڋ��r)d#	��:�}�֭� �s/8      Z      x������ � �      [   �  x�œ�n�0�g�)͡A)�ȱ� 12^�%FB*pl/E�L]�
N���R$�=��{�MJ�K�x �8�G��wwsY:_QᔧRbI��z�3e-j�.����tr�a�vS�V�I��[2����դ��EU�f1_V���'uߝ��v�i��#]��tdՄ}ĕI=l�:��w��6d1��#зͰ���y3ln�=�� �
N@.��Ơ4�HY��M��WX%�
�Epmѕ=b8ɤ�:�{-�����4=�6�&�=�6�oQ��}����&H��q�����t�1[R�Q�u�9�B�<��D����*���� 	�r#�Xdē`V���ZP��QY!�t2W�E��e"_6ߗ��v����~y\w�Y�¶�}��|�&µ܍�b��韮�ƣ��.��      f   :  x�34�44�H�a����[��J2��32���]�K8c����ЌӀ3 ��<���ʇ��B(Y��g���k!$��)�y
�w/MV��8�9W��Hs�B��]�Q���x!g��͉D�24 i#�S�@�!�W�̞���&�J#NCb�(K����&��@���	�VC#P�aq��]�Kq��1�N���|HI=����Gaؼf2�Q�5 �P�ƈ+?���0_t�Ġi2�4ĝn�/̃�� '�IY��Uh�X����p�G&^1�9� s!F�v#�v���\r��ÛLb���� c��>      \   �  x��VKn#7]˧�T��#Y:Ĝ`6��d� �}�����j�!�#����X�Gᤡ�	��y�/�RK�SsE�}O�oH�o?�����wJD�	�%�ݙ�%K9�������f���X�Q��H��,�~�Ѝ��t���s�rX�,xad�Y]�bD�b���aBǪ{�X�$����|�G-����=���c�"s@��`(�l��u��wt� ��|I�|��\�N�0X��/�5��/��7����=�#qA�-��@�B�Y�"����L�䂐���"�(�Y6B�TxM@�G������F�8����/!��PQF� h�@��� �"T0n�,�)�.�z�������=�"��"��������h!�a���D���V�~���y݁�ͷ�#�Y���n�Uß8PD'C���i���2�{���]���e�\�G�Z�ӷ�i��Դ�Bc>C����o���!���	�%��,�B��!���e��c�k	��"�zg<�Q��H�[��N�G�7GY@�V�.4��~��`���9��#GU�^�h�n#�7�����f���qT�����<���ށ�	��,;���C��
M���Z�(����V�<�1�-���c�w��[�H��t���� �3*0��AK=��ܸ��^���柏�#����48�Ոp�-��fK�ՃAOl����r��V<�p۴��gk�ĸ�N!�v7�Al�1�M���v���r���6?g�QU������Uk�4�5��5q{��蕜8�����8���x H!��lJ_2b��k�K�\�B�3��҃���ѫ�Y&_!�ٟ���i�Y��
�-4�?O�����8�Hk��.��X��c
us珊���n��j_�bQ��p�zx9��\��2rO}��K��H%pBZ��}�Kͨ���x�������q�������      ]      x��[�oǑ��d� Q��}$w���heN搗Ւ�H��� >B`��3�p8%	�ql߃I������\U�t�T����ꏪ����|/N��Q�f��ߗ��Xܜ�������:;��l����d񺜰g��[�^��������\�3����tuw3�l��Φ��ugW��|��d�V�/�ί��O<�\��G�Y}��t�m~������ޟ7������ǶFly��k9B��0����Os��|wE�T�zG�ltJ!��X�x��}�.Nwc6��8����d%��G����`���
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
e�Ӹi\i��x�i�����>���VS��vt}Be����(�գS�`T�؏��o<Iw������&�Ok����K��%������Ʃ.^l�ms�p���lou�G�>�����Óp��X~E��⇱ʥ���珴��7�����"��c��֓+(��ʺ������	he�m��W��r�!����6|��j���������}�o�	4�SXu1�S�U�8��Й��ƯZi�#t�Rl���k����ݣé��^��F��~�W`k>@4!���ơ�[��a���.N�fEy����:���!�F��M��ow�����C=*].�b�Xd��-748�|m�$4N�i2�M �y	�Ǣh��+�Q��#�-��p���0�h�D�a�x�~ �%ǱH�c��_�W���������+�	1�O��"�<���M��DI�i�iYM��܌��"������dU��@d[3�-[f�e�8�4w���A�pM�.�kBT^}�	U�q��3^������+-@��+���:b-TMe$�-�M��q�:�j�V5��_:B�t3�ͻ������(�&H�5��Ď���bOo�N����'�|��j��i      e     x�����AE�y��jh�$�w���C_*���Xct�k�U6����� ��|��|,� _Y��bP���ul\�� �����3<��Τ: +NX��ݮ�����P*��蹔c)�b�%�"���Aȃ�e\�u�h�+��)��9��F�"��
�e#�_䩫;Z���-�$x؂���[o�|�N�
���9�!D�_��ѰCj\w��k�i ^��>ri�1����4���9e���Hc�F�1��-|w(����¢�����I���~�ᐖ�VA�ܫ֓XK�7L��έ��	��,�%�
�œ�tNN׶��#e�'ۦ��Cr׍K���s���[���C!j/�.���'�.,ŕ�r�0��#�m�[���0���(�R�\�|GWW#O@t����z*�f����K�7��z�[K�-���CZ���ph}�&$fW��>�c�Tu�����1���l�["=�"��^@��O�^=�m���v��9`��GK���6��V�M������~���      d   <  x����n[7��GO!dOy����E���@Wِ��m4p��H���]�#}��Qd)vlY�4C����(��^�jIN*4W(���	\���~��Cî��wu��-f-B�N�۵����9s�=���n����z����������v(������?n�n"�AK�5�5������痂�Ģ�j�1D� �=�،�R�%@N񨇇��?yʻ6`��c&ש��^w���Tb(���x�M�9b�kЕPD�o��Q�0#{j��\���Ӝ\�N�;����������l����j6W�ۋ�a��+ACxV�!��M;���.e�N����h�gV(h��Q�9�A���bs��8	\�sM��}�Z�^�r7���}�fj�&���^߭�v7��߽�暫�Y������}���˷�>��|����{����y	�]sXy@���KQ��$`�qYZsR��8�6�(Ik�|�>���@~�����k�+6D�O��ʾ�C���I�щ�'Pr�B�Pq���o7f�tӆ�M�����x}~��e�i-�2�������R_������>/2����Cͦ��+ų��r	4jN�(M�n�������������[�OQ�'ДG$�ќ�6�1d��1R� *��$��y��2�쭴F�U��я���E��h�.b���"��]h�dn��zM�<X<��Z����
�J��c�PB�E���Vu&`y�Uڣ�
P��b�\+�F{7 g&���**H��;����/� *��H�{R�sap�k��\'�tc-6���[#�^F���*'�*bJ�r��v^�]-�� �o?p      ^     x��U�j�@=��b~��VҮ�k|h�r0�B.�B�"�&Ĳ���C��Pz�UK-��T/9���dd)T�F6�7o�y#"X���Ι�z�C�2vtP�u��Pٿ�w�3�F���`q��uB�{�"��c���N��s=b�XT^��.f���d�e{6O`��I���oZA������e-��(�]�4��hD�*�H�<�u�3��9�>Q��̗t���ՙZv�vO�X=y��8�!��(ř�.����ŵ\o5\(���Rl�9A�0u��c)��vOuE&}�	kv"�jP���R<E�4�9Rb��$�g~��tt�*%�j"�5�)��
��M�����N�=<C�3?ൽ�xe���ы3���MŒ��q�u�h�DG�j.�UCX�~�y��	��N���/ת	�����3�pq&n>��7M k0kOKԢ� q���:�~>��q����Ó;�$`/��I�xĽz��$=���9�ya��gR�ai�s��&���M�Pk�*ʈ���G;�N�_C4�      _   �   x���1N�0Dk���������t4�T�j;��H��.�-9���MP
 @L;���I������� �:R	(c�Be2���k\E�r����r:�>��xXN�t~y�W��ܶ�"��M12�t����w�,@�6W��)�֖1�O��Zb2\�߉X��2-�~�m�8��/�2Z;�Ą���z).N*	����@-�SI&8�q�Y��G�zo��W�O���o�d�      `   �   x�����1�3��eƐ�} C�!�7���T]-M7wBE�tA+U��QR�<1�l̆�6��77��XIU/����p�����UM ��f��7�%�~S�L`a�X���~�$i��#�-�6t���w��:q}����+���r,�0��N��T�blyp�����}h��>]4����;�|@���xŔM�����N��=��LO�F	�tՕ��+�6���y��ԗv�      a   �   x��ͻ1 ���<|�ԋ�������)��7���j�#
�Թ��1O��q�q�aH��R״'��npZZ���	�`�Rm�z�z$NW�+�5-�b�'k�z=����ods�if�#��}?��� Ϊ8�      b   �   x�m�=N�0��zr
_`������ H4T�؁,)���ᨹ^A���W�=]}�:j���t�-��ukU�,�;0����X(*������~���v�q!dF�D��-*����W^�\���n�6v�7\[�+6E����r�p�����1{N��<H�t!���o��B4;�j����p��4O����?�      c   '   x�320224040�4155����,�4�3г����� lXi     