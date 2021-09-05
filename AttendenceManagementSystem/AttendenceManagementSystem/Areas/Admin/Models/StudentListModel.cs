﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendenceManagementSystem.Attendence.Services;
using AttendenceManagementSystem.Models;
using Autofac;
using Microsoft.AspNetCore.Http;

namespace AttendenceManagementSystem.Areas.Admin.Models
{
    public class StudentListModel
    {
        private readonly IAttendenceService _attendenceService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public StudentListModel()
        {
            _attendenceService = Startup.AutofacContainer.Resolve<IAttendenceService>();
            _httpContextAccessor= Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
        }
        public StudentListModel(IAttendenceService attendenceService, IHttpContextAccessor httpContextAccessor)
        {
            _attendenceService = attendenceService;
            _httpContextAccessor = httpContextAccessor;
        }

        internal object GetStudentData(DataTablesAjaxRequestModel dataTableModel)
        {
            var data = _attendenceService.GetStudents(
                dataTableModel.PageIndex,
                dataTableModel.PageSize,
                dataTableModel.SearchText,
                dataTableModel.GetSortText(new string[] {"Name", "StudentRollNumber"}));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Name,
                            record.StudentRollNumber.ToString(),
                            record.Id.ToString()
                        }
                    ).ToArray()
            };
        }

        internal void Delete(int id)
        {
            _attendenceService.DeleteStudent(id);
        }
    }
}