﻿using RSoft.Lib.Design.Infra.Data;
using System.Diagnostics.CodeAnalysis;

namespace RSoft.Person.Infra
{

    /// <summary>
    /// Unit of work object to maintain the integrity of transactional operations
    /// </summary>
    [ExcludeFromCodeCoverage(Justification = "Anemic class")]
    public class UnitOfWork : UnitOfWorkBase, IUnitOfWork
    {

        #region Constructors

        /// <summary>
        /// Create a new UnitOfWork instance
        /// </summary>
        /// <param name="ctx">Database context object</param>
        public UnitOfWork(PersonContext ctx) : base(ctx) { }

        #endregion

    }
}
