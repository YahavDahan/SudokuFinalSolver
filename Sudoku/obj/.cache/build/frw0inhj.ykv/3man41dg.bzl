<!DOCTYPE html>
<!--[if IE]><![endif]-->
<html>
  
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>Class SudokuBoardSolver
   </title>
    <meta name="viewport" content="width=device-width">
    <meta name="title" content="Class SudokuBoardSolver
   ">
    <meta name="generator" content="docfx 2.59.0.0">
    
    <link rel="shortcut icon" href="../favicon.ico">
    <link rel="stylesheet" href="../styles/docfx.vendor.css">
    <link rel="stylesheet" href="../styles/docfx.css">
    <link rel="stylesheet" href="../styles/main.css">
    <meta property="docfx:navrel" content="../toc.html">
    <meta property="docfx:tocrel" content="toc.html">
    
    
    
  </head>
  <body data-spy="scroll" data-target="#affix" data-offset="120">
    <div id="wrapper">
      <header>
        
        <nav id="autocollapse" class="navbar navbar-inverse ng-scope" role="navigation">
          <div class="container">
            <div class="navbar-header">
              <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#navbar">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
              </button>
              
              <a class="navbar-brand" href="../index.html">
                <img id="logo" class="svg" src="../logo.svg" alt="">
              </a>
            </div>
            <div class="collapse navbar-collapse" id="navbar">
              <form class="navbar-form navbar-right" role="search" id="search">
                <div class="form-group">
                  <input type="text" class="form-control" id="search-query" placeholder="Search" autocomplete="off">
                </div>
              </form>
            </div>
          </div>
        </nav>
        
        <div class="subnav navbar navbar-default">
          <div class="container hide-when-search" id="breadcrumb">
            <ul class="breadcrumb">
              <li></li>
            </ul>
          </div>
        </div>
      </header>
      <div role="main" class="container body-content hide-when-search">
        
        <div class="sidenav hide-when-search">
          <a class="btn toc-toggle collapse" data-toggle="collapse" href="#sidetoggle" aria-expanded="false" aria-controls="sidetoggle">Show / Hide Table of Contents</a>
          <div class="sidetoggle collapse" id="sidetoggle">
            <div id="sidetoc"></div>
          </div>
        </div>
        <div class="article row grid-right">
          <div class="col-md-10">
            <article class="content wrap" id="_content" data-uid="Sudoku.Logic.SudokuBoardSolver">
  
  
  <h1 id="Sudoku_Logic_SudokuBoardSolver" data-uid="Sudoku.Logic.SudokuBoardSolver" class="text-break">Class SudokuBoardSolver
  </h1>
  <div class="markdown level0 summary"></div>
  <div class="markdown level0 conceptual"></div>
  <div class="inheritance">
    <h5>Inheritance</h5>
    <div class="level0"><span class="xref">System.Object</span></div>
    <div class="level1"><span class="xref">SudokuBoardSolver</span></div>
  </div>
  <div class="inheritedMembers">
    <h5>Inherited Members</h5>
    <div>
      <span class="xref">System.Object.ToString()</span>
    </div>
    <div>
      <span class="xref">System.Object.Equals(System.Object)</span>
    </div>
    <div>
      <span class="xref">System.Object.Equals(System.Object, System.Object)</span>
    </div>
    <div>
      <span class="xref">System.Object.ReferenceEquals(System.Object, System.Object)</span>
    </div>
    <div>
      <span class="xref">System.Object.GetHashCode()</span>
    </div>
    <div>
      <span class="xref">System.Object.GetType()</span>
    </div>
    <div>
      <span class="xref">System.Object.MemberwiseClone()</span>
    </div>
  </div>
  <h6><strong>Namespace</strong>: <a class="xref" href="Sudoku.Logic.html">Sudoku.Logic</a></h6>
  <h6><strong>Assembly</strong>: Sudoku.dll</h6>
  <h5 id="Sudoku_Logic_SudokuBoardSolver_syntax">Syntax</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public static class SudokuBoardSolver</code></pre>
  </div>
  <h3 id="fields">Fields
  </h3>
  <span class="small pull-right mobile-hide">
    <span class="divider">|</span>
    <a href="https://github.com/YahavDahan/SudokuFinalSolver/new/ProjectDocumentation/apiSpec/new?filename=Sudoku_Logic_SudokuBoardSolver_locationsOfBoardchangesStack.md&amp;value=---%0Auid%3A%20Sudoku.Logic.SudokuBoardSolver.locationsOfBoardchangesStack%0Asummary%3A%20'*You%20can%20override%20summary%20for%20the%20API%20here%20using%20*MARKDOWN*%20syntax'%0A---%0A%0A*Please%20type%20below%20more%20information%20about%20this%20API%3A*%0A%0A">Improve this Doc</a>
  </span>
  <span class="small pull-right mobile-hide">
    <a href="https://github.com/YahavDahan/SudokuFinalSolver/blob/ProjectDocumentation/Sudoku/Logic/SudokuBoardSolver.cs/#L12">View Source</a>
  </span>
  <h4 id="Sudoku_Logic_SudokuBoardSolver_locationsOfBoardchangesStack" data-uid="Sudoku.Logic.SudokuBoardSolver.locationsOfBoardchangesStack">locationsOfBoardchangesStack</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public static Stack&lt;int&gt; locationsOfBoardchangesStack</code></pre>
  </div>
  <h5 class="fieldValue">Field Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><span class="xref">System.Collections.Generic.Stack</span>&lt;<span class="xref">System.Int32</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h3 id="methods">Methods
  </h3>
  <span class="small pull-right mobile-hide">
    <span class="divider">|</span>
    <a href="https://github.com/YahavDahan/SudokuFinalSolver/new/ProjectDocumentation/apiSpec/new?filename=Sudoku_Logic_SudokuBoardSolver_CountLegalNumbersInCurrentIndex_Sudoku_Board_System_Int32_System_Int32_.md&amp;value=---%0Auid%3A%20Sudoku.Logic.SudokuBoardSolver.CountLegalNumbersInCurrentIndex(Sudoku.Board%2CSystem.Int32%2CSystem.Int32)%0Asummary%3A%20'*You%20can%20override%20summary%20for%20the%20API%20here%20using%20*MARKDOWN*%20syntax'%0A---%0A%0A*Please%20type%20below%20more%20information%20about%20this%20API%3A*%0A%0A">Improve this Doc</a>
  </span>
  <span class="small pull-right mobile-hide">
    <a href="https://github.com/YahavDahan/SudokuFinalSolver/blob/ProjectDocumentation/Sudoku/Logic/SudokuBoardSolver.cs/#L64">View Source</a>
  </span>
  <a id="Sudoku_Logic_SudokuBoardSolver_CountLegalNumbersInCurrentIndex_" data-uid="Sudoku.Logic.SudokuBoardSolver.CountLegalNumbersInCurrentIndex*"></a>
  <h4 id="Sudoku_Logic_SudokuBoardSolver_CountLegalNumbersInCurrentIndex_Sudoku_Board_System_Int32_System_Int32_" data-uid="Sudoku.Logic.SudokuBoardSolver.CountLegalNumbersInCurrentIndex(Sudoku.Board,System.Int32,System.Int32)">CountLegalNumbersInCurrentIndex(Board, Int32, Int32)</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public static int CountLegalNumbersInCurrentIndex(Board board, int row, int col)</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Sudoku.Board.html">Board</a></td>
        <td><span class="parametername">board</span></td>
        <td></td>
      </tr>
      <tr>
        <td><span class="xref">System.Int32</span></td>
        <td><span class="parametername">row</span></td>
        <td></td>
      </tr>
      <tr>
        <td><span class="xref">System.Int32</span></td>
        <td><span class="parametername">col</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><span class="xref">System.Int32</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <span class="small pull-right mobile-hide">
    <span class="divider">|</span>
    <a href="https://github.com/YahavDahan/SudokuFinalSolver/new/ProjectDocumentation/apiSpec/new?filename=Sudoku_Logic_SudokuBoardSolver_FindMinimumLocation_Sudoku_Board_.md&amp;value=---%0Auid%3A%20Sudoku.Logic.SudokuBoardSolver.FindMinimumLocation(Sudoku.Board)%0Asummary%3A%20'*You%20can%20override%20summary%20for%20the%20API%20here%20using%20*MARKDOWN*%20syntax'%0A---%0A%0A*Please%20type%20below%20more%20information%20about%20this%20API%3A*%0A%0A">Improve this Doc</a>
  </span>
  <span class="small pull-right mobile-hide">
    <a href="https://github.com/YahavDahan/SudokuFinalSolver/blob/ProjectDocumentation/Sudoku/Logic/SudokuBoardSolver.cs/#L70">View Source</a>
  </span>
  <a id="Sudoku_Logic_SudokuBoardSolver_FindMinimumLocation_" data-uid="Sudoku.Logic.SudokuBoardSolver.FindMinimumLocation*"></a>
  <h4 id="Sudoku_Logic_SudokuBoardSolver_FindMinimumLocation_Sudoku_Board_" data-uid="Sudoku.Logic.SudokuBoardSolver.FindMinimumLocation(Sudoku.Board)">FindMinimumLocation(Board)</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public static int FindMinimumLocation(Board board)</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Sudoku.Board.html">Board</a></td>
        <td><span class="parametername">board</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><span class="xref">System.Int32</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <span class="small pull-right mobile-hide">
    <span class="divider">|</span>
    <a href="https://github.com/YahavDahan/SudokuFinalSolver/new/ProjectDocumentation/apiSpec/new?filename=Sudoku_Logic_SudokuBoardSolver_Solver_Sudoku_Board_.md&amp;value=---%0Auid%3A%20Sudoku.Logic.SudokuBoardSolver.Solver(Sudoku.Board)%0Asummary%3A%20'*You%20can%20override%20summary%20for%20the%20API%20here%20using%20*MARKDOWN*%20syntax'%0A---%0A%0A*Please%20type%20below%20more%20information%20about%20this%20API%3A*%0A%0A">Improve this Doc</a>
  </span>
  <span class="small pull-right mobile-hide">
    <a href="https://github.com/YahavDahan/SudokuFinalSolver/blob/ProjectDocumentation/Sudoku/Logic/SudokuBoardSolver.cs/#L14">View Source</a>
  </span>
  <a id="Sudoku_Logic_SudokuBoardSolver_Solver_" data-uid="Sudoku.Logic.SudokuBoardSolver.Solver*"></a>
  <h4 id="Sudoku_Logic_SudokuBoardSolver_Solver_Sudoku_Board_" data-uid="Sudoku.Logic.SudokuBoardSolver.Solver(Sudoku.Board)">Solver(Board)</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public static bool Solver(Board sudokuBoardToSolve)</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Sudoku.Board.html">Board</a></td>
        <td><span class="parametername">sudokuBoardToSolve</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><span class="xref">System.Boolean</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
</article>
          </div>
          
          <div class="hidden-sm col-md-2" role="complementary">
            <div class="sideaffix">
              <div class="contribution">
                <ul class="nav">
                  <li>
                    <a href="https://github.com/YahavDahan/SudokuFinalSolver/new/ProjectDocumentation/apiSpec/new?filename=Sudoku_Logic_SudokuBoardSolver.md&amp;value=---%0Auid%3A%20Sudoku.Logic.SudokuBoardSolver%0Asummary%3A%20'*You%20can%20override%20summary%20for%20the%20API%20here%20using%20*MARKDOWN*%20syntax'%0A---%0A%0A*Please%20type%20below%20more%20information%20about%20this%20API%3A*%0A%0A" class="contribution-link">Improve this Doc</a>
                  </li>
                  <li>
                    <a href="https://github.com/YahavDahan/SudokuFinalSolver/blob/ProjectDocumentation/Sudoku/Logic/SudokuBoardSolver.cs/#L9" class="contribution-link">View Source</a>
                  </li>
                </ul>
              </div>
              <nav class="bs-docs-sidebar hidden-print hidden-xs hidden-sm affix" id="affix">
                <h5>In This Article</h5>
                <div></div>
              </nav>
            </div>
          </div>
        </div>
      </div>
      
      <footer>
        <div class="grad-bottom"></div>
        <div class="footer">
          <div class="container">
            <span class="pull-right">
              <a href="#top">Back to top</a>
            </span>
            
            <span>Generated by <strong>DocFX</strong></span>
          </div>
        </div>
      </footer>
    </div>
    
    <script type="text/javascript" src="../styles/docfx.vendor.js"></script>
    <script type="text/javascript" src="../styles/docfx.js"></script>
    <script type="text/javascript" src="../styles/main.js"></script>
  </body>
</html>
