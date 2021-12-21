Public Class Form1
    Public Nodes As New List(Of Cities)
    Public Edges As New List(Of Routes)
    Public Ants As New List(Of Swarms)

    Public Class Cities
        Dim _XCoord As Integer
        Dim _YCoord As Integer

        Public ReadOnly Property XCoord() As Integer
            Get
                Return _XCoord
            End Get
        End Property

        Public ReadOnly Property YCoord() As Integer
            Get
                Return _YCoord
            End Get
        End Property

        Public Sub New(ByVal X As Integer, ByVal Y As Integer)
            _XCoord = X
            _YCoord = Y
        End Sub
    End Class

    Public Class Routes
        Dim _Tau As Double
        Dim _Eita As Double
        Dim _Dist As Double
        Dim _i As Integer
        Dim _j As Integer
        Dim _PAlpha As Integer

        Public ReadOnly Property PAlpha() As Integer
            Get
                Return _PAlpha
            End Get
        End Property

        Public ReadOnly Property Tau() As Double
            Get
                Return _Tau
            End Get
        End Property

        Public ReadOnly Property Eita() As Double
            Get
                Return _Eita
            End Get
        End Property

        Public ReadOnly Property Dist() As Double
            Get
                Return _Dist
            End Get
        End Property

        Public ReadOnly Property i() As Integer
            Get
                Return _i
            End Get
        End Property

        Public ReadOnly Property j() As Integer
            Get
                Return _j
            End Get
        End Property

        Public Function FindMe(ByVal Ti As Integer, ByVal Tj As Integer) As Boolean
            If (Ti = _i And Tj = _j) Or (Ti = _j And Tj = _i) Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Sub New(ByVal i0 As Integer, ByVal j0 As Integer, ByVal T As Double, ByVal D As Double)
            _i = i0
            _j = j0
            _Tau = T
            _Dist = D
            _Eita = 1 / D
        End Sub

        Public Sub UpdateTau(ByVal rho As Double, ByVal dTau As Double)
            _Tau = ((1 - rho) * _Tau) + dTau
        End Sub

        Public Sub UpdatePAlpha(ByVal MaxTau As Double, ByVal itt As Double)
            _PAlpha = (_Tau / MaxTau) * 254 * itt
        End Sub

        Public Sub DirectUpdateTau(ByVal Tau As Double, ByVal NormalizeD As Double)
            _Tau = Tau
            _Dist = _Dist / NormalizeD
            _Eita = 1 / _Dist
        End Sub

        Public Function TauEita(ByVal alpha As Double, ByVal beta As Double) As Double
            TauEita = (_Tau ^ alpha) * (_Eita ^ beta)
        End Function
    End Class

    Public Class PossibleRoutes
        Public FRindex As Integer
        Public TOindex As Integer
        Public Probab As Double
    End Class

    Public Class Swarms
        Dim _DistCovered As Double
        Dim _StartCity As Integer
        Dim _CitiesTrail() As Integer

        Public ReadOnly Property DistCovered() As Double
            Get
                Return _DistCovered
            End Get
        End Property

        Public ReadOnly Property StartCity() As Integer
            Get
                Return _StartCity
            End Get
        End Property

        Public ReadOnly Property CitiesTrail() As Integer()
            Get
                Return _CitiesTrail
            End Get
        End Property

        Public Sub New(ByVal S As Integer, ByVal CT() As Integer, ByVal Dist As Double)
            _StartCity = S
            _CitiesTrail = CT
            _DistCovered = Dist
        End Sub
    End Class


    Public Function IndexOfTarget(ByVal IList() As Integer, ByVal TIndex As Integer)
        Dim findex As Integer = -1
        For lv1 As Integer = 0 To (IList.Count - 1) Step 1
            If IList(lv1) = TIndex Then
                findex = lv1
                Exit For
            End If
        Next
        Return findex
    End Function


    Public Function RandomTrail(ByVal StartCity As Integer, ByVal NumOfCities As Integer) As Integer()
        '--------------- Function returns random trail ---------------------
        Dim trail(NumOfCities) As Integer

        For lv1 As Integer = 0 To (NumOfCities - 1) Step 1
            trail(lv1) = lv1
        Next

        Dim r As Integer
        Dim idx As Integer
        Dim temp1 As Integer
        Dim temp2 As Integer

        For lv1 = 0 To (NumOfCities - 1) Step +1
            '--------- Fisher Yates Shuffle algorithm
            r = (New Random).Next(lv1, NumOfCities)
            temp1 = trail(r)
            trail(r) = trail(lv1)
            trail(lv1) = temp1
        Next

        idx = IndexOfTarget(trail, StartCity)
        temp2 = trail(0)
        trail(0) = trail(idx)
        trail(idx) = temp2
        trail(NumOfCities) = StartCity

        Return trail
    End Function

    Public Function ActualTrail(ByVal StartCity As Integer, ByVal NumOfCities As Integer, ByVal alpha As Integer, ByVal beta As Integer) As Integer()
        '--------------- Function returns Actual trail based on Pheromone Concentration ----------
        Dim trail(NumOfCities) As Integer
        Dim TempTrailList As New List(Of Integer)
        Dim tempProb As New PossibleRoutes
        Dim tempV As Integer
        Dim tempD As Double
        Dim Prob As New List(Of PossibleRoutes)
        Dim maxProbab As Double
        Dim SummTauEita As Double '--- Stores summation of Tau and Eita
        Dim TListCount As Integer = 0

        For lv1 = 0 To (NumOfCities - 1) Step +1
            '--------- Add all city or node
            TempTrailList.Add(lv1)
        Next
        '------ Remove the randomly chosen start city
        trail(0) = StartCity
        TListCount = TListCount + 1 '----One item added to trail list
        TempTrailList.Remove(trail(0))

        Do Until (TempTrailList.Count = 0)
            '------- Calculate the summation of Tau and Eita
            SummTauEita = 0
            Dim tempV1 As Integer
            For Each TTList In TempTrailList
                tempV1 = TTList
                SummTauEita = SummTauEita + Edges.Find(Function(X) X.FindMe(tempV1, trail(TListCount - 1))).TauEita(alpha, beta)
            Next


            '------- Calculate the porbability for each possible routes
            Prob.Clear()
            tempD = 0
            For Each TTList In TempTrailList
                tempV1 = TTList
                tempD = Edges.Find(Function(X) X.FindMe(tempV1, trail(TListCount - 1))).TauEita(alpha, beta)
                tempD = tempD / SummTauEita

                tempProb = New PossibleRoutes
                tempProb.FRindex = trail(TListCount - 1)
                tempProb.TOindex = tempV1
                tempProb.Probab = tempD
                Prob.Add(tempProb)
            Next

            '-------- Finding the index of max probability
            maxProbab = Prob.Max(Function(x) x.Probab)
            trail(TListCount) = Prob.Find(Function(X) X.Probab = maxProbab).TOindex


            TListCount = TListCount + 1
            TempTrailList.Remove(trail(TListCount - 1))
        Loop

        trail(NumOfCities) = StartCity
        Return trail
    End Function

    Private Sub Button_Simulate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Simulate.Click
        '*****************************************************
        '*********  Initializing Variable ********************
        '*****************************************************
        Label_Status.Text = ""
        Dim Rnd1 As New Random
        Dim NC As Integer
        Dim EC As Integer
        Dim lv1 As Integer
        Dim lv2 As Integer
        NC = Val(TextBox_NCities.Text)
        '------- Exit if Invalid input
        If IsNumeric(NC) = False Or NC = 0 Then
            Exit Sub
        End If

        '------ Initializing Nodes
        Nodes = New List(Of Cities) '<<<<<<---------- Nodes
        Dim TempN As Cities
        For lv1 = 0 To (NC - 1) Step 1
            '----- range of 25 to 325
            TempN = New Cities(Rnd1.Next(25, 325), Rnd1.Next(25, 325))
            Nodes.Add(TempN)
        Next

        '------ Initializing Edges
        EC = (NC * (NC - 1)) / 2
        Edges = New List(Of Routes) '<<<<<<---------- Edges
        Dim TempE As Routes
        Dim TTotalDist As Double = 0
        Dim TempDist As Double
        For lv1 = 1 To NC - 1 Step +1
            For lv2 = lv1 + 1 To NC Step +1
                TempDist = Math.Sqrt(((Nodes(lv1 - 1).XCoord - Nodes(lv2 - 1).XCoord) ^ 2) + ((Nodes(lv1 - 1).YCoord - Nodes(lv2 - 1).YCoord) ^ 2))
                TempE = New Routes(lv1 - 1, lv2 - 1, 1, TempDist) '--- Give tau value as 1 for initial
                TTotalDist = TTotalDist + TempDist
                Edges.Add(TempE)
            Next
        Next
        TempDist = Edges.Max(Function(X) X.Dist)
        '_____________________________________________________
        '*****************************************************
        '*********  Initial Rouste Seeking     ***************
        '*****************************************************
        '------ Update Tau m/C and Normalize Distance
        For lv1 = 0 To (EC - 1) Step 1
            Edges(lv1).DirectUpdateTau(1, TempDist)   'NC / TTotalDist
        Next

        Dim alpha As Double
        Dim beta As Double
        Dim rho As Double
        Dim m As Integer
        Dim iterations As Integer

        m = NC '---- Number of Ants = Number of Ciites
        alpha = 1 '-- setting parameters
        beta = 3 '-- setting parameters
        rho = 0.5 '-- setting evaporation rate
        iterations = 100
        Ants = New List(Of Swarms) '<<<<<<---------- Ants

        '------ First Route
        Dim RStart As Integer = 0
        Dim RTrail(NC - 1) As Integer
        Dim DistCoveredS As Double
        Dim DeltaRho As Double
        Dim TempAnts As Swarms

        For lv1 = 0 To (m - 1) Step +1
            RStart = Rnd1.Next(0, NC - 1) '--- Give Random Start to each
            RTrail = RandomTrail(RStart, NC) 'ActualTrail(RStart, NC, alpha, beta) '--- Find Random Trail for the initial case
            DistCoveredS = 0 '--- Store Distance Covered
            lv2 = 0
            Do Until (lv2 > NC - 1) '--- Loop till 2 city before so that succesive nodes can be added
                DistCoveredS = DistCoveredS + Edges.Find(Function(X) X.FindMe(RTrail(lv2), RTrail(lv2 + 1))).Dist
                lv2 = lv2 + 1
            Loop
            DeltaRho = DeltaRho + (1 / DistCoveredS) '---- Delta Rho is the only information required to modify global pheromone trail and nothing else matters
            TempAnts = New Swarms(RStart, RTrail, DistCoveredS)
            Ants.Add(TempAnts) '---- Keep track of All Ants for no reason
        Next
        '-------- Evaporate Pheromone trails Tau values
        For lv1 = 0 To (EC - 1) Step 1
            Edges(lv1).UpdateTau(rho, 0)
        Next

        '-------- Add Pheromone trails Tau values
        DeltaRho = Ants.Min(Function(y) y.DistCovered)
        lv1 = Ants.IndexOf(Ants.Find(Function(y) y.DistCovered = DeltaRho))
        DeltaRho = 1 / DeltaRho
        Dim tempA1 As New Swarms(Ants(lv1).StartCity, Ants(lv1).CitiesTrail, Ants(lv1).DistCovered)
        lv1 = 0
        Do Until (lv1 > NC - 1)
            Edges.Find(Function(X) X.FindMe(tempA1.CitiesTrail(lv1), tempA1.CitiesTrail(lv1 + 1))).UpdateTau(0, DeltaRho)
            lv1 = lv1 + 1
        Loop


        PictureBox_PathPic.Refresh()
        'MsgBox("break")

        '_____________________________________________________
        '*****************************************************
        '*********  Actual Rouste Seeking     ****************
        '*****************************************************
        Ants = New List(Of Swarms) '<<<<<<---------- Ants
        Dim maxTau As Double
        For lv1 = 1 To iterations Step +1
            Ants = New List(Of Swarms) '<<<<<<---------- Ants
            DeltaRho = 0
            For lv2 = 0 To (m - 1) Step +1
                RStart = Rnd1.Next(0, NC - 1) '--- Give Random Start to each
                RTrail = ActualTrail(RStart, NC, alpha, beta) '--- Find Random Trail for the initial case
                DistCoveredS = 0 '--- Store Distance Covered
                Dim lv3 As Integer = 0
                Do Until (lv3 > NC - 1) '--- Loop till 2 city before so that succesive nodes can be added
                    DistCoveredS = DistCoveredS + Edges.Find(Function(X) X.FindMe(RTrail(lv3), RTrail(lv3 + 1))).Dist
                    lv3 = lv3 + 1
                Loop
                DeltaRho = DeltaRho + (1 / DistCoveredS) '---- Delta Rho is the only information required to modify global pheromone trail and nothing else matters
                TempAnts = New Swarms(RStart, RTrail, DistCoveredS)
                Ants.Add(TempAnts) '---- Keep track of All Ants for no reason
            Next
            '-------- Evaporate Pheromone trails Tau values
            For lv2 = 0 To (EC - 1) Step 1
                Edges(lv2).UpdateTau(rho, 0)
            Next
            '-------- Update Pheromone trails Tau values only for the ant which successfully completed the tour in shortest distance
            DeltaRho = Ants.Min(Function(y) y.DistCovered)
            lv2 = Ants.IndexOf(Ants.Find(Function(y) y.DistCovered = DeltaRho))
            DeltaRho = 1 / DeltaRho
            Dim tempA2 As New Swarms(Ants(lv2).StartCity, Ants(lv2).CitiesTrail, Ants(lv2).DistCovered)
            lv2 = 0
            Do Until (lv2 > NC - 1)
                Edges.Find(Function(X) X.FindMe(tempA2.CitiesTrail(lv2), tempA2.CitiesTrail(lv2 + 1))).UpdateTau(0, DeltaRho)
                lv2 = lv2 + 1
            Loop


            maxTau = Edges.Max(Function(x) x.Tau)
            For lv2 = 0 To (EC - 1) Step 1
                Edges(lv2).UpdatePAlpha(maxTau, 1) '(lv1 / iterations))
            Next

            PictureBox_PathPic.Refresh()
            'MsgBox("Break")
        Next

        Label_Status.Text = "Finished"
        PictureBox_PathPic.Refresh()
    End Sub

    Private Sub Panel_PathPic_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel_PathPic.Paint
        '------------- Painting the cities after initialization
        If Nodes.Count = 0 Then
            Exit Sub
        End If

        Dim City_pen1 As New Pen(Color.Red, 1)
        Dim City_pen2 As New Pen(Color.Black, 1)
        Dim Edge_pen1 As New Pen(Color.FromArgb(1, 255, 50, 50), 2)
        Dim Edge_pen2 As New Pen(Color.Black, 1)

        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality

        For Each Ns In Nodes
            e.Graphics.FillEllipse(City_pen2.Brush, Ns.XCoord - 4, Ns.YCoord - 4, 8, 8)
            e.Graphics.FillEllipse(City_pen1.Brush, Ns.XCoord - 2, Ns.YCoord - 2, 4, 4)
            e.Graphics.DrawString(Nodes.IndexOf(Ns) + 1, New Font("Verdana", 8), City_pen1.Brush, Ns.XCoord - 12, Ns.YCoord - 12)
        Next

        For Each Ed In Edges
            Edge_pen1 = New Pen(Color.FromArgb(Ed.PAlpha, 0, 50, 50), 1)
            e.Graphics.DrawLine(Edge_pen1, Nodes(Ed.i).XCoord, Nodes(Ed.i).YCoord, Nodes(Ed.j).XCoord, Nodes(Ed.j).YCoord)
            'e.Graphics.DrawLine(Edge_pen2, Nodes(Ed.i).XCoord, Nodes(Ed.i).YCoord, Nodes(Ed.j).XCoord, Nodes(Ed.j).YCoord)
            e.Graphics.DrawString(Math.Round(Ed.Dist, 4), New Font("Verdana", 8), City_pen1.Brush, ((Nodes(Ed.i).XCoord + Nodes(Ed.j).XCoord) * 0.5) - 12, ((Nodes(Ed.i).YCoord + Nodes(Ed.j).YCoord) * 0.5) - 12)
        Next

    End Sub
End Class

