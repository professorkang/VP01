﻿namespace _019_listbox
{
  partial class Form1
  {
    /// <summary>
    /// 필수 디자이너 변수입니다.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// 사용 중인 모든 리소스를 정리합니다.
    /// </summary>
    /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form 디자이너에서 생성한 코드

    /// <summary>
    /// 디자이너 지원에 필요한 메서드입니다. 
    /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
    /// </summary>
    private void InitializeComponent()
    {
      this.label1 = new System.Windows.Forms.Label();
      this.listBox1 = new System.Windows.Forms.ListBox();
      this.txtSIndex1 = new System.Windows.Forms.TextBox();
      this.txtSItem1 = new System.Windows.Forms.TextBox();
      this.txtSItem2 = new System.Windows.Forms.TextBox();
      this.txtSIndex2 = new System.Windows.Forms.TextBox();
      this.listBox2 = new System.Windows.Forms.ListBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtSItem3 = new System.Windows.Forms.TextBox();
      this.txtSIndex3 = new System.Windows.Forms.TextBox();
      this.listBox3 = new System.Windows.Forms.ListBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.label1.Location = new System.Drawing.Point(102, 43);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(59, 15);
      this.label1.TabIndex = 0;
      this.label1.Text = "GDP 순위";
      // 
      // listBox1
      // 
      this.listBox1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.listBox1.FormattingEnabled = true;
      this.listBox1.ItemHeight = 15;
      this.listBox1.Items.AddRange(new object[] {
            "미국",
            "중국",
            "일본",
            "독일",
            "영국",
            "인도",
            "프랑스",
            "이탈리아",
            "캐나다",
            "대한민국"});
      this.listBox1.Location = new System.Drawing.Point(104, 76);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new System.Drawing.Size(144, 214);
      this.listBox1.TabIndex = 1;
      this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
      // 
      // txtSIndex1
      // 
      this.txtSIndex1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.txtSIndex1.Location = new System.Drawing.Point(104, 318);
      this.txtSIndex1.Name = "txtSIndex1";
      this.txtSIndex1.Size = new System.Drawing.Size(144, 23);
      this.txtSIndex1.TabIndex = 2;
      // 
      // txtSItem1
      // 
      this.txtSItem1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.txtSItem1.Location = new System.Drawing.Point(104, 357);
      this.txtSItem1.Name = "txtSItem1";
      this.txtSItem1.Size = new System.Drawing.Size(144, 23);
      this.txtSItem1.TabIndex = 3;
      // 
      // txtSItem2
      // 
      this.txtSItem2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.txtSItem2.Location = new System.Drawing.Point(294, 357);
      this.txtSItem2.Name = "txtSItem2";
      this.txtSItem2.Size = new System.Drawing.Size(144, 23);
      this.txtSItem2.TabIndex = 7;
      // 
      // txtSIndex2
      // 
      this.txtSIndex2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.txtSIndex2.Location = new System.Drawing.Point(294, 318);
      this.txtSIndex2.Name = "txtSIndex2";
      this.txtSIndex2.Size = new System.Drawing.Size(144, 23);
      this.txtSIndex2.TabIndex = 6;
      // 
      // listBox2
      // 
      this.listBox2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.listBox2.FormattingEnabled = true;
      this.listBox2.ItemHeight = 15;
      this.listBox2.Location = new System.Drawing.Point(294, 76);
      this.listBox2.Name = "listBox2";
      this.listBox2.Size = new System.Drawing.Size(144, 214);
      this.listBox2.TabIndex = 5;
      this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.label2.Location = new System.Drawing.Point(292, 43);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(111, 15);
      this.label2.TabIndex = 4;
      this.label2.Text = "살기좋은 도시 순위";
      // 
      // txtSItem3
      // 
      this.txtSItem3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.txtSItem3.Location = new System.Drawing.Point(485, 357);
      this.txtSItem3.Name = "txtSItem3";
      this.txtSItem3.Size = new System.Drawing.Size(144, 23);
      this.txtSItem3.TabIndex = 11;
      // 
      // txtSIndex3
      // 
      this.txtSIndex3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.txtSIndex3.Location = new System.Drawing.Point(485, 318);
      this.txtSIndex3.Name = "txtSIndex3";
      this.txtSIndex3.Size = new System.Drawing.Size(144, 23);
      this.txtSIndex3.TabIndex = 10;
      // 
      // listBox3
      // 
      this.listBox3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.listBox3.FormattingEnabled = true;
      this.listBox3.ItemHeight = 15;
      this.listBox3.Location = new System.Drawing.Point(485, 76);
      this.listBox3.Name = "listBox3";
      this.listBox3.Size = new System.Drawing.Size(144, 214);
      this.listBox3.TabIndex = 9;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.label3.Location = new System.Drawing.Point(483, 43);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(99, 15);
      this.label3.TabIndex = 8;
      this.label3.Text = "행복한 나라 순위";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.label4.Location = new System.Drawing.Point(12, 323);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(88, 15);
      this.label4.TabIndex = 12;
      this.label4.Text = "SelectedIndex :";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.label5.Location = new System.Drawing.Point(12, 362);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(83, 15);
      this.label5.TabIndex = 13;
      this.label5.Text = "SelectedItem :";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(656, 409);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.txtSItem3);
      this.Controls.Add(this.txtSIndex3);
      this.Controls.Add(this.listBox3);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txtSItem2);
      this.Controls.Add(this.txtSIndex2);
      this.Controls.Add(this.listBox2);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txtSItem1);
      this.Controls.Add(this.txtSIndex1);
      this.Controls.Add(this.listBox1);
      this.Controls.Add(this.label1);
      this.Name = "Form1";
      this.Text = "ListBox";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ListBox listBox1;
    private System.Windows.Forms.TextBox txtSIndex1;
    private System.Windows.Forms.TextBox txtSItem1;
    private System.Windows.Forms.TextBox txtSItem2;
    private System.Windows.Forms.TextBox txtSIndex2;
    private System.Windows.Forms.ListBox listBox2;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtSItem3;
    private System.Windows.Forms.TextBox txtSIndex3;
    private System.Windows.Forms.ListBox listBox3;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
  }
}

