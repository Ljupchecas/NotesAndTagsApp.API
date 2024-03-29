﻿using NotesAndTagsApp.DTOs;
using NotesAndTagsApp.Services.Implementation;
using NotesAndTagsApp.Services.Interfaces;
using NotesAndTagsApp.Shared.CustomExceptions;
using NotesAndTagsApp.Tests.FakeRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesAndTagsApp.Tests
{
    [TestClass]
    public class NoteServiceWithOutMoqTest
    {
        [TestMethod]
        public void AddNote_InvalidUserId_Exception()
        {
            //Arrange
            INoteService noteService = new NoteService(new FakeNoteRepository(), new FakeUserRepository());

            var newNote = new AddNoteDto()
            {
                Priority = Domain.Enums.PriorityEnum.Low,
                Tag = Domain.Enums.TagEnum.SEDC,
                Text = "Do you work in SEDC now",
                UserId = 3
            };

            //Act and assert
            Assert.ThrowsException<NoteDataException>(() => noteService.AddNote(newNote));
        }

        [TestMethod]
        public void AddNote_EmptyText_Exception()
        {
            //Arrange
            INoteService noteService = new NoteService(new FakeNoteRepository(), new FakeUserRepository());

            var newNote = new AddNoteDto()
            {
                Priority = Domain.Enums.PriorityEnum.Low,
                Tag = Domain.Enums.TagEnum.SEDC,
                Text = "",
                UserId = 1
            };

            //Act and Assert
            Assert.ThrowsException<NoteDataException>(() => noteService.AddNote(newNote));
        }

        [TestMethod]
        public void AddNote_LargerText_Exception()
        {
            //Arrange
            INoteService noteService = new NoteService(new FakeNoteRepository(), new FakeUserRepository());

            var newNote = new AddNoteDto()
            {
                Priority = Domain.Enums.PriorityEnum.Low,
                Tag = Domain.Enums.TagEnum.SEDC,
                Text = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                UserId = 1
            };

            //Act and Assert
            Assert.ThrowsException<NoteDataException>(() => noteService.AddNote(newNote));
        }

        [TestMethod]
        public void GetAllNotes_Count()
        {
            //Arrange
            INoteService noteService = new NoteService(new FakeNoteRepository(), new FakeUserRepository());
            var exceptionCount = 2;

            //Act
            var result = noteService.GetAllNotes();

            //Assert
            Assert.AreEqual(exceptionCount, result.Count);
        }

        [TestMethod]
        public void GetById_InvalidId_Exception()
        {
            //Arrange
            INoteService noteService = new NoteService(new FakeNoteRepository(), new FakeUserRepository());

            //Act and Assert
            Assert.ThrowsException<NoteNotFoundException>(() => noteService.GetById(3));
        }

    }
}
