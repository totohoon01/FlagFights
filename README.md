## 유니티 포톤 개인과제

### 과제 주제 : 이전 제작 게임 또는 신규 게임 
### 과제 마감 : 2021년 5월 3일 오후 6:00 까지
### 과제 업로드 : [메디치 카페] - [2021 혁신 가산 VR/AR] - [IITP_과제/실습]
- 사용할 리소스
- 에셋스토어에서 리소스 다운로드 후 사용
- 자체 제작 리소스도 사용가능


### 반드시 포함되어야 할 사항
- [x] 소스코드는 Git으로 관리 (CLI 만 사용 - GUI 툴 사용 금지)
- [x] Github에 원격 리포지토리에 백업
- [x] 로비 구현 생성 (유저ID, 룸생성 로직, 룸 목록(옵션사항))
- [x] 로비 씬, 베틀 씬으로 구성함
- [ ] OnPhotonSerializeView 콜백 함수 사용
- [x] RPC로 구현한 로직 하나 이상 구현


### 구현 To do!
    
- [x] 샘플 맵, 플레이어 구현
- [x] 깃발 모델, 플레이어가 접근하면 해당 플레이어 차일드로 들어가고 따로 표식생김

- Player Parts
    - [x] 기본 움직임(이동, 점프)
    - [x] 캐릭터 생성 로직(랜덤 색상 or 모델)

- Map Parts
    - [x] 중심 기준으로 플레이어 생성
    - [ ] 맵 몇 개 구현


- GameManage Parts
    - [x] 중앙에 깃발 생성 로직
    - [x] 시간 세팅
    - [x] 누가 깃발을 가지고 있는가?
    - [x] 플레이어가 맵 밖으로 나갈 경우? 





## 게임 진행

- <b>로비</b> 1-> 타이틀, 방 목록 / 방 생성 버튼, 방 입장 버튼(1/4)
    
- <b>방(대기실</b>) -> 참가자 리스트, 스타트버튼, 나가기버튼

- <b>인게임</b> -> 4명이 각각 아바타를 할당(랜덤)받고 지정된 위치 리스폰
- 깃발 처음에 가운데, 누가 먹으면 그사람에게 귀속
- 제한시간(300)초 안에 게임 진행
- 시간이 끝나면 네 캐릭터 정렬, 카메라 정면, 각각 애니메이션
- 다시 <b>대기실</b>로