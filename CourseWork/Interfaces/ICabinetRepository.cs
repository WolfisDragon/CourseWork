﻿using CourseWork.Models;

namespace CourseWork.Interfaces;

public interface ICabinetRepository
{ 
    Task<List<Cabinet>> GetAllAsync();
    Task<Cabinet> GetByIdAsync(int id);
    Task<Cabinet> CreateCabinetAsync(Cabinet cabinet);
}
