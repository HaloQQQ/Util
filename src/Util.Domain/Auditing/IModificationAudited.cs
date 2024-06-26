﻿namespace Util.Domain.Auditing; 

/// <summary>
/// 修改操作审计
/// </summary>
public interface IModificationAudited : IModificationAudited<Guid?> {
}

/// <summary>
/// 修改操作审计
/// </summary>
/// <typeparam name="TKey">最后修改人标识类型</typeparam>
public interface IModificationAudited<TKey> : ILastModificationTime {
    /// <summary>
    /// 最后修改人标识
    /// </summary>
    TKey LastModifierId { get; set; }
}