﻿using System;

namespace repository
{
    /// <summary>
    /// Define la funcionalidad básica de un repositorio.
    /// </summary>
    public interface IRepository : IDisposable
    {
        /// <summary>
        /// Indicador de transacción en curso.
        /// <see langword="true"/>, si existe una transacción en curso;
        /// de lo contrario, <see langword="false"/>.
        /// </summary>
        bool IsInTransaction { get; }
        /// <summary>
        /// Inicia una transacción.
        /// </summary>        
        void BeginTransaction();
        /// <summary>
        /// Realiza una salva manteniendo la transacción abierta.
        /// </summary>
        void PartialCommit();
        /// <summary>
        /// Finaliza y da persistencia a una transacción.
        /// </summary>
        void CommitTransaction();
        /// <summary>
        /// Deshace una transacción, si esta no se ha finalizado.
        /// </summary>
        void RollbackTransaction();
    }
}

