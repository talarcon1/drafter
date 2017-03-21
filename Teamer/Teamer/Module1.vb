Module Module1

    Sub Main()
        '//@TA DELETE
        '//TESTING
        Dim d As New Drafter


        'players = SetPlayersNameSkill(noPlayers, New Collection)
        d.Players = d.TestTeam()
        'Dim newplayers = ShufflePlayers(players)

        d.AverageRank = d.GetTotalPlayersSkill(d.Players) / d.NoTeams


        'players = New Collection
        'For i = 1 To noPlayers
        '    Dim player As New Baller("Player" & i, i)
        '    players.Add(player, player.Skill)
        'Next
        Dim proceed As Boolean = True
        While proceed = True
            d.ResetDraftedPlayers(d.Players)
            d.FinalTeam = New Collection
            d.Players = d.ShufflePlayers(d.Players)

            d.Draft(1)
            If d.bPrintedTeams Then
                Console.ReadLine()
            Else
                d.Deviation += 1
            End If

        End While


    End Sub
    Public Class Drafter
        Private _deviation As Integer
        Public Property Deviation() As Integer
            Get
                Return _deviation
            End Get
            Set(ByVal value As Integer)
                _deviation = value
            End Set
        End Property


        Private _noTeams As Integer
        Public Property NoTeams() As Integer
            Get
                Return _noTeams
            End Get
            Set(ByVal value As Integer)
                _noTeams = value
            End Set
        End Property


        Private _noPlayers As Integer
        Public Property NoPlayers() As Integer
            Get
                Return _noPlayers
            End Get
            Set(ByVal value As Integer)
                _noPlayers = value
            End Set
        End Property

        Private _averageRank As Integer
        Public Property AverageRank() As Integer
            Get
                Return _averageRank
            End Get
            Set(ByVal value As Integer)
                _averageRank = value
            End Set
        End Property

        Private _playersPerTeam As Integer
        Public Property PlayersPerTeam() As Integer
            Get
                Return _playersPerTeam
            End Get
            Set(ByVal value As Integer)
                _playersPerTeam = value
            End Set
        End Property

        Private _bPrintedTeams As Boolean
        Public Property bPrintedTeams() As Boolean
            Get
                Return _bPrintedTeams
            End Get
            Set(ByVal value As Boolean)
                _bPrintedTeams = value
            End Set
        End Property

        Private _players As Collection
        Public Property Players() As Collection
            Get
                Return _players
            End Get
            Set(ByVal value As Collection)
                _players = value
            End Set
        End Property

        Private _FinalTeam As Collection
        Public Property FinalTeam() As Collection
            Get
                Return _FinalTeam
            End Get
            Set(ByVal value As Collection)
                _FinalTeam = value
            End Set
        End Property


        Private _iteraton As Integer
        Public Property Iteration() As Integer
            Get
                Return _iteraton
            End Get
            Set(ByVal value As Integer)
                _iteraton = value
            End Set
        End Property


        Public Const SUCCESS As Short = 0
        Public Const FAILURE As Short = 1

        Public Sub New()
            Deviation = 0
            NoTeams = 4
            NoPlayers = 12
            PlayersPerTeam = NoPlayers / NoTeams
        End Sub
        Public Function TestTeam() As Collection
            TestTeam = New Collection
            TestTeam.Add(New Baller("Ric", 67))
            TestTeam.Add(New Baller("Tico", 72))
            TestTeam.Add(New Baller("Jr", 74))
            TestTeam.Add(New Baller("Fur", 77))
            TestTeam.Add(New Baller("Jamie", 86))
            TestTeam.Add(New Baller("Danny", 76))
            TestTeam.Add(New Baller("Gab", 79))
            TestTeam.Add(New Baller("X", 86))
            TestTeam.Add(New Baller("Tim", 87))
            TestTeam.Add(New Baller("Josh", 88))
            TestTeam.Add(New Baller("Sam", 91))
            TestTeam.Add(New Baller("Zues", 84))
        End Function
        Public Sub testFairness()
            Dim testcollection As New Collection
            testcollection.Add(New Baller("", 19))
            testcollection.Add(New Baller("", 0))
            testcollection.Add(New Baller("", 0))
            testcollection.Add(New Baller("", 20))
            testcollection.Add(New Baller("", 0))
            testcollection.Add(New Baller("", 0))
            testcollection.Add(New Baller("", 21))
            testcollection.Add(New Baller("", 0))
            testcollection.Add(New Baller("", 0))
            testcollection.Add(New Baller("", 20))
            testcollection.Add(New Baller("", 0))
            testcollection.Add(New Baller("", 0))
            Console.WriteLine(GetFairness(testcollection, 3))
        End Sub
        Public Function GetFairness(ByRef players As Collection, ByVal playersPerTeam As Integer) As Decimal
            GetFairness = 100
            Dim allTeamsSkills As New Collection
            For x = 1 To players.Count
                Dim teamSkill As Integer = 0
                For y = 1 To playersPerTeam
                    teamSkill += players(x).skill
                    x += 1
                Next
                x -= 1
                allTeamsSkills.Add(teamSkill)
            Next
            If AverageRank = 0 Then
                AverageRank = (GetTotalPlayersSkill(players) / NoTeams)
            End If
            For Each skillTotal In allTeamsSkills
                Dim test = skillTotal / AverageRank
                Dim test2 As Decimal = 1 - test
                Dim test3 = Math.Abs(test2)
                Dim test4 = test3 * 100D
                Dim test5 = GetFairness - test4
                GetFairness -= Math.Abs(1 - (skillTotal / AverageRank)) * 100
            Next
        End Function
        Public Function GetTotalPlayersSkill(ByRef players As Collection) As Integer
            GetTotalPlayersSkill = 0
            For Each player As Baller In players
                GetTotalPlayersSkill += player.Skill
            Next
        End Function
        Public Function SetPlayersNameSkill(ByVal noPlayers As Integer, ByRef players As Collection) As Collection
            SetPlayersNameSkill = New Collection
            For x = 1 To noPlayers
                Console.WriteLine("Enter Player " & x)
                Dim sPlayer As String = Console.ReadLine()
                '   Dim name As String = sPlayer.Split(" ")(0)
                '  Dim skill As String = sPlayer.Split(" ")(1)
                'Dim xplayer As New Baller(sPlayer.Split(" ")(0), sPlayer.Split(" ")(1))
                players.Add(New Baller(sPlayer.Split(" ")(0), sPlayer.Split(" ")(1)))
                ' players.Add(xplayer, xplayer.Skill)
            Next
            SetPlayersNameSkill = players
        End Function
        Public Sub ResetDraftedPlayers(ByRef players As Collection)
            For Each player As Baller In players
                player.IsDrafted = False
            Next
        End Sub
        Public Function TeamSkill(ByVal i As Integer) As Integer
            TeamSkill = Players(i).skill
            Try

                Dim position As Integer = (FinalTeam.Count + 1) Mod PlayersPerTeam
                Dim goBack As Integer = position - 1 ' Math.Abs(playersPerTeam - position)
                If goBack < 0 Then
                    goBack = PlayersPerTeam - 1
                End If
                For j = 0 To goBack - 1
                    TeamSkill += FinalTeam(FinalTeam.Count - j).skill

                Next
            Catch ex As Exception

            End Try

        End Function
        Public Function ShufflePlayers(ByVal players As Collection) As Collection
            ShufflePlayers = players
            Dim editPlayers As New Collection
            Dim shuffledPlayers As New Collection
            For Each player In players
                editPlayers.Add(player)
            Next

            Dim count As Integer = editPlayers.Count
            Dim r As New Random
            For x = 1 To editPlayers.Count
                Dim ranNum As Integer = r.Next(editPlayers.Count) + 1
                shuffledPlayers.Add(editPlayers(ranNum))
                editPlayers.Remove(ranNum)
            Next
            Return shuffledPlayers
        End Function


        Public Sub Draft(ByVal i As Integer)

            Iteration += 1
            ' Dim totalSkill As Integer
            ' Dim position As Integer
            Try
                'Dim position As Integer = i Mod playersPerTeam
                '//Check if inside collection bounds
                If i = 0 Then 'i <= players.Count Or i = 0 Then

                    If FinalTeam.Count = NoPlayers Then
                        PrintTeams()
                    End If
                ElseIf i > Players.Count Then

                Else
                    '//Check if player is not on team
                    If Not Players(i).isdrafted Then
                        '//Check their position, 0 = last member, 1 = first Member, 2 = second memeber
                        If (FinalTeam.Count + 1) Mod PlayersPerTeam = 0 Then
                            'if position = 0 then
                            '//3rd member, check if team is is acceptable

                            If TeamSkill(i) >= (AverageRank - Deviation) And TeamSkill(i) <= (AverageRank + Deviation) Then
                                '//team is done, move on to next team, start with lowest available player in collection
                                Players(i).isDrafted = True
                                FinalTeam.Add(Players(i)) ', iteration)
                                '//Reset the collection, start with not available
                                Draft(lowestAvail)
                                If FinalTeam.Count <> Players.Count Then
                                    FinalTeam.Remove(FinalTeam.Count)
                                    Players(i).isDrafted = False
                                    Draft(i + 2)
                                End If
                            Else '//team is not acceptable move on
                                Draft(i + 1)
                            End If
                        Else '//player is not last rank
                            '//Test total skill of this rank
                            If TeamSkill(i) >= AverageRank Then '//too many skillfull players do not add this person
                                Draft(i + 1)
                            Else '//Player fits on team
                                FinalTeam.Add(Players(i)) ', iteration)
                                Players(i).isDrafted = True
                                Draft(i + 1)
                                If FinalTeam.Count <> Players.Count Then
                                    FinalTeam.Remove(FinalTeam.Count)
                                    Players(i).isDrafted = False
                                    Draft(i + 2)
                                End If
                            End If
                        End If
                    Else '//player is already drafted
                        Draft(i + 1)
                    End If




                End If
            Catch ex As Exception
                Console.WriteLine("Error on iteration: " & Iteration)
                Console.ReadLine()
            End Try
        End Sub
        Public Function lowestAvail() As Integer
            lowestAvail = 0
            For i = 1 To NoTeams
                If Not Players(i).isDrafted Then
                    lowestAvail = i
                    Exit For
                End If
            Next
        End Function


        Public Sub PrintTeams()
            Dim teamCount As Integer = 1
            For i = 1 To FinalTeam.Count
                If i Mod PlayersPerTeam = 1 Then
                    Console.WriteLine()
                    Console.WriteLine("-----------")
                    Console.WriteLine("TEAM " & teamCount)
                    Console.WriteLine("-----------")
                    teamCount += 1

                End If
                Console.WriteLine(FinalTeam(i).name) ' & " " & FinalTeam(i)

            Next
            Console.WriteLine()
            Console.WriteLine("Fairness: " & GetFairness(FinalTeam, PlayersPerTeam) & "%")
            bPrintedTeams = True
        End Sub
    End Class

    Public Class Baller
        Private _isDrafted As Boolean
        Public Property IsDrafted() As Boolean
            Get
                Return _isDrafted
            End Get
            Set(ByVal value As Boolean)
                _isDrafted = value
            End Set
        End Property


        Private _skill As Integer
        Public Property Skill() As Integer
            Get
                Return _skill
            End Get
            Set(ByVal value As Integer)
                _skill = value
            End Set
        End Property



        Private _name As String
        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property

        Sub New(ByVal anyName As String, ByVal anySkill As Integer)
            Name = anyName
            Skill = anySkill
        End Sub

    End Class
End Module
