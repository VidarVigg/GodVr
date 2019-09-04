using System;
using UnityEngine;

[Serializable]
public struct Model
{

    #region Fields

    [SerializeField]
    private Mesh mesh;

    [SerializeField]
    private Texture texture;

    #endregion

    #region Properties

    public Mesh Mesh
    {
        get { return mesh; }
    }

    public Texture Texture
    {
        get { return texture; }
    }

    #endregion

    #region Constructor

    public Model(Mesh mesh, Texture texture)
    {
        this.mesh = mesh;
        this.texture = texture;
    }

    #endregion

}