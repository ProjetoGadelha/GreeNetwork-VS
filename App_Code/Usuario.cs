using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Usuario
/// </summary>
public class Usuario
{
    #region ATRIBUTOS
    private int idUser;
    private string nomeUser;
    private string emailUser;
    private string passUser;
    private string cpfUser;
    private int nivelUser;
    private string apelidoUser;
    private int RsultInsert = 0;
    #endregion

    #region PROPRIEDADES
    public int IdUser
    {
        get { return idUser; }
        set { idUser = value; }
    }
    public string NomeUser
    {
        get { return nomeUser; }
        set { nomeUser = value; }
    }
    public string EmailUser
    {
        get { return emailUser; }
        set { emailUser = value; }
    }
    public string PassUser
    {
        get { return passUser; }
        set { passUser = value; }
    }
    public string CpfUser
    {
        get { return cpfUser; }
        set { cpfUser = value; }
    }
    public int NivelUser
    {
        get { return nivelUser; }
        set { nivelUser = value; }
    }
    public string ApelidoUser
    {
        get { return apelidoUser; }
        set { apelidoUser = value; }
    }
    #endregion

    #region METODOS
    public void Insert()
    {
        var db = WebMatrix.Data.Database.Open("GreeNetwork");
        RsultInsert = db.Execute("INSERT INTO usuario (nome_user, email_user, pass_user, cpf_user, nivel_user, apelido_user) VALUES (@0, @1, @2, @3, @4, @5) ", NomeUser, EmailUser, PassUser, CpfUser, NivelUser, ApelidoUser);
        db.Close();
    }
    public static Usuario Login(string Login, string Pass)
    {
        try
        {
            var db = WebMatrix.Data.Database.Open("GreeNetwork");

            dynamic user = db.QuerySingle("SELECT * FROM usuario WHERE email_user = @0 AND pass_user = @1", Login, Pass);
            db.Close();
            if (user != null)
            {
                Usuario ObjUser = new Usuario();
                ObjUser.IdUser = user.id_user;
                ObjUser.NomeUser = user.nome_user;
                ObjUser.ApelidoUser = user.apelido_user;
                ObjUser.EmailUser = user.email_user;
                ObjUser.NivelUser = Convert.ToInt32(user.nivel_user);
                ObjUser.CpfUser = user.cpf_user;
                ObjUser.passUser = string.Empty;
                return ObjUser;
            }
            else
            {
                return null;
            }
        }
        catch (Exception)
        {
            return null;
        }
    }
    public Usuario()
    {
        //
        // TODO: Adicionar lógica do construtor aqui
        //
    }
    public Usuario(dynamic user)
    {
        this.IdUser = user.id_user;
        this.NomeUser = user.nome_user;
        this.ApelidoUser = user.apelido_user;
        this.EmailUser = user.email_user;
        this.NivelUser = user.nivel_user;
        this.CpfUser = user.cpf_user;
        this.passUser = string.Empty;
    }
    #endregion
}