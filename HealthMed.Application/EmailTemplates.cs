using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application
{
    public static class EmailTemplates
    {
        public static string GetNewMedicalAppointmentEmail(
            string doctorName, string patientName, DateTime scheduleDate)
        {
            return NewMedicalAppointmentEmail
            .Replace("{{DoctorName}}", doctorName)
            .Replace("{{PatientName}}", patientName)
            .Replace("{{ScheduleDate}}", scheduleDate.ToString("dd/MM/yyyy"))
            .Replace("{{ScheduleTime}}", scheduleDate.ToString("hh:mm"));
        }

        private const string NewMedicalAppointmentEmail = """
        <!DOCTYPE html>
        <html lang="en">
        <head>
            <meta charset="UTF-8">
            <meta name="viewport" content="width=device-width, initial-scale=1.0">
            <title>Health&Med - Nova consulta agendada</title>
            <style>
                body {
                    font-family: 'Arial', sans-serif;
                    background-color: #f9f9f9;
                    color: #333;
                    margin: 0;
                    padding: 0;
                }
                .container {
                    max-width: 600px;
                    margin: 20px auto;
                    background-color: #ffffff;
                    padding: 30px;
                    border-radius: 8px;
                    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
                }
                .header {
                    text-align: center;
                    padding-bottom: 20px;
                    border-bottom: 1px solid #eeeeee;
                }
                .header h1 {
                    margin: 0;
                    color: #2a9d8f;
                    font-size: 24px;
                }
                .content {
                    padding: 20px 0;
                    line-height: 1.6;
                }
                .content p {
                    margin: 15px 0;
                }
                .btn {
                    display: inline-block;
                    padding: 12px 20px;
                    font-size: 16px;
                    color: #ffffff;
                    background-color: #2a9d8f;
                    text-decoration: none;
                    border-radius: 5px;
                    margin: 20px 0;
                    text-align: center;
                }
                .btn:hover {
                    background-color: #21867a;
                }
                .footer {
                    text-align: center;
                    padding-top: 20px;
                    border-top: 1px solid #eeeeee;
                    font-size: 12px;
                    color: #777777;
                }
            </style>
        </head>
        <body>
            <div class="container">
                <div class="header">
                    <h1>Olá, Dr. {{DoctorName}}!</h1>
                </div>
                <div class="content">
                    <p>Você tem uma nova consulta marcada! Paciente: {{PatientName}}.</p>
                    <p>Data e horário: {{ScheduleDate}} às {{ScheduleTime}}.</p>
                </div>
            </div>
        </body>
        </html>
        """;
    }
}
