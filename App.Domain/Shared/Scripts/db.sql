IF OBJECT_ID(N'[migrations]') IS NULL
BEGIN
    CREATE TABLE [migrations] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK_migrations] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Group] (
    [id] int NOT NULL IDENTITY,
    [created_date] datetime NOT NULL DEFAULT (getutcdate()),
    [updated_date] datetime NOT NULL DEFAULT (getutcdate()),
    CONSTRAINT [PK_Group] PRIMARY KEY ([id])
);
GO

CREATE TABLE [students] (
    [id] int NOT NULL IDENTITY,
    [created_date] datetime NOT NULL DEFAULT (getutcdate()),
    [updated_date] datetime NOT NULL DEFAULT (getutcdate()),
    [name] varchar(500) NOT NULL,
    [dni] varchar(100) NOT NULL,
    CONSTRAINT [PK_students] PRIMARY KEY ([id])
);
GO

CREATE TABLE [courses] (
    [id] int NOT NULL IDENTITY,
    [created_date] datetime NOT NULL DEFAULT (getutcdate()),
    [updated_date] datetime NOT NULL DEFAULT (getutcdate()),
    [name] varchar(500) NOT NULL,
    [group_id] int NOT NULL,
    CONSTRAINT [PK_courses] PRIMARY KEY ([id]),
    CONSTRAINT [FK_courses_Group_group_id] FOREIGN KEY ([group_id]) REFERENCES [Group] ([id])
);
GO

CREATE TABLE [asignments] (
    [id] int NOT NULL IDENTITY,
    [created_date] datetime NOT NULL DEFAULT (getutcdate()),
    [updated_date] datetime NOT NULL DEFAULT (getutcdate()),
    [student_id] int NOT NULL,
    [course_id] int NOT NULL,
    CONSTRAINT [PK_asignments] PRIMARY KEY ([id]),
    CONSTRAINT [FK_asignments_courses_course_id] FOREIGN KEY ([course_id]) REFERENCES [courses] ([id]),
    CONSTRAINT [FK_asignments_students_student_id] FOREIGN KEY ([student_id]) REFERENCES [students] ([id])
);
GO

CREATE TABLE [marks] (
    [id] int NOT NULL IDENTITY,
    [created_date] datetime NOT NULL DEFAULT (getutcdate()),
    [updated_date] datetime NOT NULL DEFAULT (getutcdate()),
    [asignment_id] int NOT NULL,
    [mark] decimal(5,3) NOT NULL,
    CONSTRAINT [PK_marks] PRIMARY KEY ([id]),
    CONSTRAINT [FK_marks_asignments_asignment_id] FOREIGN KEY ([asignment_id]) REFERENCES [asignments] ([id])
);
GO

CREATE UNIQUE INDEX [IX_asignments_course_id_student_id] ON [asignments] ([course_id], [student_id]);
GO

CREATE INDEX [IX_asignments_student_id] ON [asignments] ([student_id]);
GO

CREATE INDEX [IX_courses_group_id] ON [courses] ([group_id]);
GO

CREATE UNIQUE INDEX [IX_courses_name_group_id] ON [courses] ([name], [group_id]);
GO

CREATE UNIQUE INDEX [IX_marks_asignment_id] ON [marks] ([asignment_id]);
GO

CREATE UNIQUE INDEX [IX_students_dni] ON [students] ([dni]);
GO

INSERT INTO [migrations] ([MigrationId], [ProductVersion])
VALUES (N'20240326220903_v_1', N'7.0.16');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [courses] DROP CONSTRAINT [FK_courses_Group_group_id];
GO

ALTER TABLE [Group] DROP CONSTRAINT [PK_Group];
GO

EXEC sp_rename N'[Group]', N'groups';
GO

ALTER TABLE [groups] ADD [name] varchar(500) NOT NULL DEFAULT '';
GO

ALTER TABLE [groups] ADD CONSTRAINT [PK_groups] PRIMARY KEY ([id]);
GO

CREATE TABLE [users] (
    [id] int NOT NULL IDENTITY,
    [created_date] datetime NOT NULL DEFAULT (getutcdate()),
    [updated_date] datetime NOT NULL DEFAULT (getutcdate()),
    [name] varchar(100) NOT NULL,
    [password] varchar(100) NOT NULL,
    CONSTRAINT [PK_users] PRIMARY KEY ([id])
);
GO

CREATE UNIQUE INDEX [IX_groups_name] ON [groups] ([name]);
GO

CREATE UNIQUE INDEX [IX_users_name] ON [users] ([name]);
GO

ALTER TABLE [courses] ADD CONSTRAINT [FK_courses_groups_group_id] FOREIGN KEY ([group_id]) REFERENCES [groups] ([id]);
GO

INSERT INTO [migrations] ([MigrationId], [ProductVersion])
VALUES (N'20240327122512_v_2', N'7.0.16');
GO

COMMIT;
GO

